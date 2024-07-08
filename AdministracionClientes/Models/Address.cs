using System.ComponentModel.DataAnnotations;

namespace AdministracionClientes.Models;

public class Address
{
    [Key] 
    public int Id { get; set; }

    [Required]
    [MaxLength(250)]
    public string Street { get; set; }
    
    [Required]
    [MaxLength(5)]
    public string Zipcode { get; set; }

    public int ClientId { get; set; }
    public Client Client { get; set; }
}