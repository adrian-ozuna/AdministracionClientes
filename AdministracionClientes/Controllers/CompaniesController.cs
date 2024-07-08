using AdministracionClientes.Dtos;
using AdministracionClientes.Interfaces;
using AdministracionClientes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> Get()
        {
            return Ok(await _companyService.GetCompaniesAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetById(int id)
        {
            return Ok(await _companyService.GetCompanyByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> Post(CreateCompanyDto createCompanyDto)
        {
            var createdCompany = await _companyService.CreateCompanyAsync(createCompanyDto);
            return Ok(createdCompany);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCompanyDto updateCompanyDto)
        {
            var updatedCompany = await _companyService.UpdateCompanyAsync(id, updateCompanyDto);
            if (updatedCompany == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _companyService.DeleteCompanyAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
