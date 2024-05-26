using Domain.Entities;
using Domain.Specifications;
using Infrastructure.Dtos;
using Infrastructure.Interfaces;

namespace Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CancelSoftwareLicensesAsync(CancelSoftwareDto model)
        {
            var accountSpec = new AccountByIdWithSoftwareLicensesSpecification(model.AccountId);
            var account = await _unitOfWork.Repository<Account>().SingleOrDefaultAsync(accountSpec);

            // if invalid accountId provided, or if given account does not have any licenses for provided software code, assume cancelling failed
            if (account == null || !account.SoftwareLicenses.Any(x=> x.SoftwareCode == model.SoftwareCode))
            {
                return false;
            }

            var licenseCancelStatus = await _unitOfWork.Repository<LicenseStatus>().SingleOrDefaultAsync(ls => ls.Code == "CA");

            foreach (var license in account.SoftwareLicenses)
            {
                license.SoftwareLicenseStatuses.Add(new SoftwareLicenseStatus
                {
                    SoftwareLicenseId = license.Id,
                    LicenseStatusId = licenseCancelStatus.Id,
                    SoftwareLicenseStatusDate = DateTime.UtcNow
                });
            }

            await _unitOfWork.Complete();
            return true;
        }

        public async Task<bool> ActivateSoftwareLicenseToDateAsync(ActivateLicenseDto model)
        {
            var accountSpec = new AccountByIdWithSoftwareLicensesSpecification(model.AccountId);
            var account = await _unitOfWork.Repository<Account>().SingleOrDefaultAsync(accountSpec);

            // if invalid accountId provided, or if given account does not have license with provided license code, assume activating failed
            if (account == null || !account.SoftwareLicenses.Any(x => x.LicenseCode == model.LicenseCode))
            {
                return false;
            }

            var licenseActiveStatus = await _unitOfWork.Repository<LicenseStatus>().SingleOrDefaultAsync(ls => ls.Code == "ACT");
            var licenseToActivate = account.SoftwareLicenses.First(x => x.LicenseCode == model.LicenseCode);
            licenseToActivate.SoftwareLicenseStatuses.Add(new SoftwareLicenseStatus
            {
                LicenseStatusId = licenseActiveStatus.Id,
                SoftwareLicenseStatusDate = DateTime.UtcNow
            });
            licenseToActivate.ValidFromDate = DateTime.UtcNow;
            licenseToActivate.ValidToDate = DateTime.Parse(model.ValidToDate);

            await _unitOfWork.Complete();

            return true;
        }
    }
}
