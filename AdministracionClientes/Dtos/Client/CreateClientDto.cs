using System.ComponentModel.DataAnnotations;

namespace AdministracionClientes.Dtos;

public class CreateClientDto
{
    [Required]
    [MaxLength(250)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(250)]
    public string LastName { get; set; }

    public int CompanyId { get; set; }
}