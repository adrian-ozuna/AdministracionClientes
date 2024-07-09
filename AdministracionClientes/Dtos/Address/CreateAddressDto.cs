using System.ComponentModel.DataAnnotations;

namespace AdministracionClientes.Dtos;

public class CreateAddressDto
{
    [Required]
    [MaxLength(250)]
    public string Street { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string City { get; set; }

    [Required]
    [MaxLength(5)]
    public string ZipCode { get; set; }

    public int ClientId { get; set; }
}