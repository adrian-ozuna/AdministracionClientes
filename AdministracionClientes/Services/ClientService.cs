using AdministracionClientes.Database;
using AdministracionClientes.Dtos;
using AdministracionClientes.Interfaces;
using AdministracionClientes.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdministracionClientes.Services;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ClientService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientDto>> GetClientsAsync()
    {
        var clients = await _context.Clients.Include(c => c.Addresses).ToListAsync();
        return _mapper.Map<IEnumerable<ClientDto>>(clients);
    }

    public async Task<ClientDto> GetClientByIdAsync(int id)
    {
        var client =  await _context.Clients.Include(c => c.Addresses)
            .FirstOrDefaultAsync(c => c.Id == id);
        
        return _mapper.Map<ClientDto>(client);
    }

    public async Task<IEnumerable<ClientDto>> GetClientByCompanyIdAsync(int id)
    {
        var clients = await _context.Clients.Include(c => c.Addresses)
            .Where(c => c.CompanyId == id)
            .ToListAsync();
        return _mapper.Map<IEnumerable<ClientDto>>(clients);
    }

    public async Task<ClientDto> CreateClientAsync(CreateClientDto dto)
    {
        var client = _mapper.Map<Client>(dto);
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return _mapper.Map<ClientDto>(client);
    }

    public async Task<ClientDto> UpdateClientAsync(int id, UpdateClientDto dto)
    {
        var client= await _context.Clients.FindAsync(id);
        if (client == null) return null;

        _mapper.Map(dto, client);
        await _context.SaveChangesAsync();
        return _mapper.Map<ClientDto>(client);
    }

    public async Task<bool> DeleteClientAsync(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return false;
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return true;
    }
}