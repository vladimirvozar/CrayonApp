using API.Dtos;
using API.Errors;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(CreateOrderDto model)
        {
            var order = await _orderService.CreateOrderAsync(model);

            if (order == null) return BadRequest(new ApiResponse(400, "Problem creating order"));

            return Ok(_mapper.Map<OrderDto>(order));
        }
    }
}
