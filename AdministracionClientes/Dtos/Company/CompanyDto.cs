using System.ComponentModel.DataAnnotations;

namespace AdministracionClientes.Dtos;

public class CompanyDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(250)]
    public string Name { get; set; }

    public ICollection<ClientDto> Clients { get; set; }
}