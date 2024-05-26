using Infrastructure.Dtos;

namespace Infrastructure.Interfaces
{
    public interface IAccountService
    {
        Task<bool> CancelSoftwareLicensesAsync(CancelSoftwareDto model);
    }
}
