using API.Dtos;
using API.Errors;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}/accounts")]
        public async Task<ActionResult<List<AccountDto>>> GetCustomerAccountsAsync(int id)
        {
            var spec = new CustomerWithAccountsSpecification(id);
            var customer = await _unitOfWork.Repository<Customer>().SingleOrDefaultAsync(spec);

            if (customer == null)
            {
                return NotFound(new ApiResponse(404, $"Customer with ID: {id} not found"));
            }

            return Ok(_mapper.Map<List<AccountDto>>(customer.Accounts));
        }
    }
}
