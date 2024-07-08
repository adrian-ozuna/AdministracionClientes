using System.ComponentModel.DataAnnotations;

namespace AdministracionClientes.Dtos;

public class UpdateClientDto
{
    [Required]
    [MaxLength(250)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(250)]
    public string LastName { get; set; }
}