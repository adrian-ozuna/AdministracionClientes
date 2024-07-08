using AdministracionClientes.Database;
using AdministracionClientes.Dtos;
using AdministracionClientes.Interfaces;
using AdministracionClientes.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdministracionClientes.Services;

public class CompanyService : ICompanyService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CompanyService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CompanyDto>> GetCompaniesAsync()
    {
        var companies = await _context.Companies.Include(c => c.Clients).ThenInclude(cl => cl.Addresses).ToListAsync();
        return _mapper.Map<IEnumerable<CompanyDto>>(companies);
    }

    public async Task<CompanyDto> GetCompanyByIdAsync(int id)
    {
        var company = await _context.Companies.Include(c => c.Clients).ThenInclude(cl => cl.Addresses)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (company == null)
        {
            return null;
        }

        return _mapper.Map<CompanyDto>(company);
    }

    public async Task<CompanyDto> CreateCompanyAsync(CreateCompanyDto dto)
    {
        var company = _mapper.Map<Company>(dto);
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return _mapper.Map<CompanyDto>(company);
    }

    public async Task<CompanyDto> UpdateCompanyAsync(int id, UpdateCompanyDto dto)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company == null) return null;

        _mapper.Map(dto, company);
        await _context.SaveChangesAsync();
        return _mapper.Map<CompanyDto>(company);
    }

    public async Task<bool> DeleteCompanyAsync(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company == null)
        {
            return false;
        }

        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
        return true;
    }
}