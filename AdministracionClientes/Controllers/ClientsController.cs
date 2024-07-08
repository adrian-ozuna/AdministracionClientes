using AdministracionClientes.Dtos;
using AdministracionClientes.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdministracionClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> Get()
        {
            var clients = await _clientService.GetClientsAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> GetById(int id)
        {
            var client = await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
        
        [HttpGet("company/{id}")]
        public async Task<ActionResult<ClientDto>> GetByCompanyId(int id)
        {
            var client = await _clientService.GetClientByCompanyIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDto>> Post(CreateClientDto dto)
        {
            var createdClient = await _clientService.CreateClientAsync(dto);
            return Ok(createdClient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateClientDto dto)
        {
            var updatedClient = await _clientService.UpdateClientAsync(id, dto);
            if (updatedClient == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clientService.DeleteClientAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
