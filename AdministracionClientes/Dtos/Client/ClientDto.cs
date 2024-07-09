using System.ComponentModel.DataAnnotations;

namespace AdministracionClientes.Dtos;

public class ClientDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(250)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(250)]
    public string LastName { get; set; }

    public ICollection<AddressDto> Addresses { get; set; }
}