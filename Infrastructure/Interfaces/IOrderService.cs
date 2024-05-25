using Domain.Entities;
using Infrastructure.Dtos;

namespace Infrastructure.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(CreateOrderDto model);
    }
}
