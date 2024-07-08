using System.ComponentModel.DataAnnotations;

namespace AdministracionClientes.Models;

public class Client
{
    [Key] 
    public int Id { get; set; }

    [Required]
    [MaxLength(250)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string LastName { get; set; }

    public int CompanyId { get; set; }
    public Company Company { get; set; }

    public ICollection<Address> Addresses { get; set; }
}