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
        private readonly IGenericRepository<SoftwareProduct> _softwareProductRepository;
        private readonly IGenericRepository<License> _licenseRepository;
        private readonly IMapper _mapper;

        public CatalogController(IGenericRepository<SoftwareProduct> softwareProductRepository,
            IGenericRepository<License> licenseRepository,
            IMapper mapper)
        {
            _softwareProductRepository = softwareProductRepository;
            _licenseRepository = licenseRepository;
            _mapper = mapper;
        }

        [HttpGet("software")]
        public async Task<ActionResult<List<SoftwareProductDto>>> GetSoftwareProductsAsync(string sort)
        {
            var spec = new SoftwareProductsWithLicensesSpecification(sort);
            var softwareProducts = await _softwareProductRepository.FindAsync(spec);
            return Ok(_mapper.Map<List<SoftwareProductDto>>(softwareProducts));
        }

        [HttpGet("software/{id:int}")]
        public async Task<ActionResult<List<SoftwareProductDto>>> GetSoftwareProductByIdAsync(int id)
        {
            var spec = new SoftwareProductsWithLicensesSpecification(id);
            var softwareProduct = await _softwareProductRepository.SingleOrDefaultAsync(spec);

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

            var totalItems = await _licenseRepository.CountAsync(countSpec);

            var licenses = await _licenseRepository.FindAsync(spec);

            var data = _mapper.Map<List<LicenseDto>>(licenses);

            return Ok(new Pagination<LicenseDto>(licensesParams.PageIndex, licensesParams.PageSize, totalItems, data));
        }
    }
}
