using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SoftwareLicensesController : ControllerBase
    {
        private readonly ISoftwareProductRepository _softwareProductRepository;

        public SoftwareLicensesController(ISoftwareProductRepository softwareProductRepository)
        {
            _softwareProductRepository = softwareProductRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<License>>> GetSoftwareProductsAsync()
        {
            var softwareProducts = await _softwareProductRepository.GetAllAsync();
            return Ok(softwareProducts);
        }
    }
}
