using AdministracionClientes.Dtos;
using AdministracionClientes.Models;
using AutoMapper;

namespace AdministracionClientes.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Company, CompanyDto>().ReverseMap();
        CreateMap<Company, CreateCompanyDto>().ReverseMap();
        CreateMap<Company, UpdateCompanyDto>().ReverseMap();

        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<Client, CreateClientDto>().ReverseMap();
        CreateMap<Client, UpdateClientDto>().ReverseMap();

        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Address, CreateAddressDto>().ReverseMap();
        CreateMap<Address, UpdateAddressDto>().ReverseMap();
    }
}