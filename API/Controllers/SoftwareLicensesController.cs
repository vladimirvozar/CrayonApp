using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoftwareLicensesController : ControllerBase
    {
        private readonly IGenericRepository<SoftwareProduct> _softwareProductRepository;
        private readonly IMapper _mapper;

        public SoftwareLicensesController(IGenericRepository<SoftwareProduct> softwareProductRepository,
            IMapper mapper)
        {
            _softwareProductRepository = softwareProductRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<SoftwareProductDto>>> GetSoftwareProductsAsync()
        {
            var spec = new SoftwareProductsWithLicensesSpecification();
            var softwareProducts = await _softwareProductRepository.FindAsync(spec);
            return Ok(_mapper.Map<List<SoftwareProductDto>>(softwareProducts));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SoftwareProductDto>>> GetSoftwareProductByIdAsync(int id)
        {
            var spec = new SoftwareProductsWithLicensesSpecification(id);
            var softwareProduct = await _softwareProductRepository.SingleOrDefaultAsync(spec);
            return Ok(_mapper.Map<SoftwareProductDto>(softwareProduct));
        }
    }
}
