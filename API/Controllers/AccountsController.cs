using API.Dtos;
using API.Errors;
using AutoMapper;
using Domain.Entities;
using Domain.Specifications;
using Infrastructure.Dtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountsController(IAccountService accountService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _accountService = accountService;
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

        [HttpPost("cancel/software")]
        public async Task<ActionResult> CancelSoftwareLicensesAsync([FromBody] CancelSoftwareDto model)
        {
            var result = await _accountService.CancelSoftwareLicensesAsync(model);

            if (result == false)
            {
                return BadRequest(new ApiResponse(400, $"Problem cancelling licenses for account ID = {model.AccountId} and software Code = {model.SoftwareCode}"));
            }

            return Ok();
        }

        [HttpPost("{id:int}/activate")]
        public async Task<ActionResult> ActivateSoftwareLicenseToDateAsync([FromBody] ActivateLicenseDto model)
        {
            var result = await _accountService.ActivateSoftwareLicenseToDateAsync(model);

            if (result == false)
            {
                return BadRequest(new ApiResponse(400, $"Problem activating license for account ID = {model.AccountId} and licence Code = {model.LicenseCode}"));
            }

            return Ok();
        }
    }
}
