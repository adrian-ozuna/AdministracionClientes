using System.ComponentModel.DataAnnotations;

namespace AdministracionClientes.Dtos;

public class UpdateAddressDto
{
    [Required]
    [MaxLength(250)]
    public string Street { get; set; }

    [Required]
    [MaxLength(5)]
    public string ZipCode { get; set; }
}