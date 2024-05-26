using API.Dtos;
using API.Errors;
using AutoMapper;
using Domain.Entities;
using Domain.Specifications;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id:int}/licenses")]
        public async Task<ActionResult<List<SoftwareLicenseDto>>> GetLicensesForAccountAsync(int id)
        {
            var accountSpec = new AccountByIdWithSoftwareLicensesSpecification(id);
            var account = await _unitOfWork.Repository<Account>().SingleOrDefaultAsync(accountSpec);

            if (account == null)
            {
                return NotFound(new ApiResponse(404, $"Account with ID = '{id}' not found"));

            }

            var softwareLicensesSpec = new SoftwareLicensesByAccountIdSpecification(id);
            var licenses = await _unitOfWork.Repository<SoftwareLicense>().FindAsync(softwareLicensesSpec);
            return Ok(_mapper.Map<List<SoftwareLicenseDto>>(licenses));
        }
    }
}
