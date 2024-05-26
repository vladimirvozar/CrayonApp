using Infrastructure.Dtos;

namespace Infrastructure.Interfaces
{
    public interface IAccountService
    {
        Task<bool> CancelSoftwareLicensesAsync(CancelSoftwareDto model);
        Task<bool> ActivateSoftwareLicenseToDateAsync(ActivateLicenseDto model);
    }
}
