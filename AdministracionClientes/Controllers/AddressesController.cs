using AdministracionClientes.Dtos;
using AdministracionClientes.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDto>>> Get()
        {
            var addresses = await _addressService.GetAddressesAsync();
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDto>> GetById(int id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPost]
        public async Task<ActionResult<AddressDto>> Post(CreateAddressDto dto)
        {
            var createdAddress = await _addressService.CreateAddressAsync(dto);
            return Ok(createdAddress);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateAddressDto dto)
        {
            var updatedAddress = await _addressService.UpdateAddressAsync(id, dto);
            if (updatedAddress == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _addressService.DeleteAddressAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
