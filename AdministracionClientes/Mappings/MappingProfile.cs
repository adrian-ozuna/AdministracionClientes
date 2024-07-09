using AdministracionClientes.Dtos;
using AdministracionClientes.Models;
using AutoMapper;

namespace AdministracionClientes.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<Client, CreateClientDto>().ReverseMap();
        CreateMap<Client, UpdateClientDto>().ReverseMap();

        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Address, CreateAddressDto>().ReverseMap();
        CreateMap<Address, UpdateAddressDto>().ReverseMap();
    }
}