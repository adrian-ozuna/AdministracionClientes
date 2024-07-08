using AdministracionClientes.Dtos;
using AdministracionClientes.Models;

namespace AdministracionClientes.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientDto>> GetClientsAsync();
    Task<ClientDto> GetClientByIdAsync(int id);
    Task<IEnumerable<ClientDto>> GetClientByCompanyIdAsync(int id);
    Task<ClientDto> CreateClientAsync(CreateClientDto dto);
    Task<ClientDto> UpdateClientAsync(int id, UpdateClientDto dto);
    Task<bool> DeleteClientAsync(int id);
}