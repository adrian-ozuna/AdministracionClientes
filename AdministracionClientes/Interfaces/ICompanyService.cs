using AdministracionClientes.Dtos;
using AdministracionClientes.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace AdministracionClientes.Interfaces;

public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetCompaniesAsync();
    Task<CompanyDto> GetCompanyByIdAsync(int id);
    Task<CompanyDto> CreateCompanyAsync(CreateCompanyDto dto);
    Task<CompanyDto> UpdateCompanyAsync(int id, UpdateCompanyDto dto);
    Task<bool> DeleteCompanyAsync(int id);
}