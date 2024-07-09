using AdministracionClientes.Database;
using AdministracionClientes.Dtos;
using AdministracionClientes.Interfaces;
using AdministracionClientes.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdministracionClientes.Services;

public class AddressService : IAddressService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AddressService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AddressDto>> GetAddressesAsync()
    {
        var addresses = await _context.Addresses.ToListAsync();
        return _mapper.Map<IEnumerable<AddressDto>>(addresses);
    }

    public async Task<AddressDto> GetAddressByIdAsync(int id)
    {
        var address = await _context.Addresses.FindAsync(id);
        return _mapper.Map<AddressDto>(address);
    }

    public async Task<AddressDto> CreateAddressAsync(CreateAddressDto dto)
    {
        var address = _mapper.Map<Address>(dto);
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();
        return _mapper.Map<AddressDto>(address);
    }
    
    public async Task<AddressDto> UpdateAddressAsync(int id, UpdateAddressDto dto)
    {
        var address = await _context.Addresses.FindAsync(id);
        if (address == null) return null;

        _mapper.Map(dto, address);
        await _context.SaveChangesAsync();
        return _mapper.Map<AddressDto>(address);
    }

    public async Task<bool> DeleteAddressAsync(int id)
    {
        var address = await _context.Addresses.FindAsync(id);
        if (address == null)
        {
            return false;
        }

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
        return true;
    }
}