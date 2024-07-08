using System.ComponentModel.DataAnnotations;

namespace AdministracionClientes.Dtos;

public class CreateCompanyDto
{
    [Required]
    [MaxLength(250)]
    public string Name { get; set; }
}