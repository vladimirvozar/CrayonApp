using Domain.Entities;
using Domain.Specifications;
using Infrastructure.Dtos;
using Infrastructure.Interfaces;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrderAsync(CreateOrderDto model)
        {
            // check if exists customer with given 'CustomerId'
            var spec = new CustomerWithAccountsSpecification(model.CustomerId);
            var customer = await _unitOfWork.Repository<Customer>().SingleOrDefaultAsync(spec);

            if (customer == null)
            {
                throw new Exception($"Customer with ID={model.CustomerId} not found");
            }

            // check if customer owns account with given 'AccountId'
            var account = customer.Accounts.SingleOrDefault(account => account.Id == model.AccountId);

            if (account == null)
            {
                throw new Exception($"Customer (CustomerId:{model.CustomerId}) does not have account with ID={model.AccountId}");
            }

            // create new Order entity based on model data
            var order = new Order
            {
                SoftwareName = model.SoftwareName,
                SoftwareCode = model.SoftwareCode,
                LicenseName = model.LicenseName,
                LicenseCode = model.LicenseCode,
                Quantity = model.Quantity,
                Price = model.Price,
                Subtotal = model.Price,
                OrderDate = DateTime.UtcNow,
                CustomerId = model.CustomerId
            };

            _unitOfWork.Repository<Order>().Add(order);
            await _unitOfWork.Complete();

            // create new SoftwareLicence object
            var softwareLicense = new SoftwareLicense
            {
                SoftwareName = model.SoftwareName,
                SoftwareCode = model.SoftwareCode,
                LicenseName = model.LicenseName,
                LicenseCode = model.LicenseCode,
                Quantity = model.Quantity,
                IsSubscription = model.IsSubscription,
                RenewalPeriod = model.RenewalPeriod,
                AccountId = model.AccountId,
                OrderId = order.Id
            };
            _unitOfWork.Repository<SoftwareLicense>().Add(softwareLicense);
            await _unitOfWork.Complete();

            // set "Not Activated" license status (initial license status)
            var licenseStatus = await _unitOfWork.Repository<LicenseStatus>().SingleOrDefaultAsync(ls => ls.Code == "NA");

            softwareLicense.SoftwareLicenseStatuses.Add(new SoftwareLicenseStatus
            {
                SoftwareLicenseId = softwareLicense.Id,
                LicenseStatusId = licenseStatus.Id,
                SoftwareLicenseStatusDate = DateTime.UtcNow
            });
            await _unitOfWork.Complete();

            return order;
        }
    }
}
