using API.Dtos;
using API.Errors;
using AutoMapper;
using Domain.Entities;
using Domain.Specifications;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CustomersController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetCustomersAsync()
        {
            var spec = new CustomersWithAddressesSpecification();
            var customers = await _unitOfWork.Repository<Customer>().FindAsync(spec);
            return Ok(_mapper.Map<List<CustomerDto>>(customers));
        }

        [HttpGet("{id}/accounts")]
        public async Task<ActionResult<List<AccountDto>>> GetCustomerAccountsAsync(int id)
        {
            var spec = new CustomerWithAccountsSpecification(id);
            var customer = await _unitOfWork.Repository<Customer>().SingleOrDefaultAsync(spec);

            if (customer == null)
            {
                return NotFound(new ApiResponse(404, $"Customer with ID={id} not found"));
            }

            return Ok(_mapper.Map<List<AccountDto>>(customer.Accounts));
        }
    }
}
