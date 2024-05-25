using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CatalogController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CatalogController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("software")]
        public async Task<ActionResult<List<SoftwareProductDto>>> GetSoftwareProductsAsync(string sort)
        {
            var spec = new SoftwareProductsWithLicensesSpecification(sort);
            var softwareProducts = await _unitOfWork.Repository<SoftwareProduct>().FindAsync(spec);
            return Ok(_mapper.Map<List<SoftwareProductDto>>(softwareProducts));
        }

        [HttpGet("software/{id:int}")]
        public async Task<ActionResult<List<SoftwareProductDto>>> GetSoftwareProductByIdAsync(int id)
        {
            var spec = new SoftwareProductsWithLicensesSpecification(id);
            var softwareProduct = await _unitOfWork.Repository<SoftwareProduct>().SingleOrDefaultAsync(spec);

            if (softwareProduct == null)
            {
                return NotFound(new ApiResponse(404));
            }

            return Ok(_mapper.Map<SoftwareProductDto>(softwareProduct));
        }

        [HttpGet("software/licenses")]
        public async Task<ActionResult<Pagination<LicenseDto>>> GetLicensesAsync([FromQuery] LicensesSpecParams licensesParams)
        {
            var spec = new LicensesWithSoftwareProductSpecification(licensesParams);

            var countSpec = new LicensesWithFiltersForCountSpecification(licensesParams);

            var totalItems = await _unitOfWork.Repository<License>().CountAsync(countSpec);

            var licenses = await _unitOfWork.Repository<License>().FindAsync(spec);

            var data = _mapper.Map<List<LicenseDto>>(licenses);

            return Ok(new Pagination<LicenseDto>(licensesParams.PageIndex, licensesParams.PageSize, totalItems, data));
        }
    }
}
