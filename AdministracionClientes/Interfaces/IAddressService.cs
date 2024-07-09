using AdministracionClientes.Dtos;
using AdministracionClientes.Models;

namespace AdministracionClientes.Interfaces;

public interface IAddressService
{
    Task<IEnumerable<AddressDto>> GetAddressesAsync();
    Task<AddressDto> GetAddressByIdAsync(int id);
    Task<AddressDto> CreateAddressAsync(CreateAddressDto dto);
    Task<AddressDto> UpdateAddressAsync(int id, UpdateAddressDto dto);
    Task<bool> DeleteAddressAsync(int id);
}