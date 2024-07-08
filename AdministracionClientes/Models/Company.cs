using System.ComponentModel.DataAnnotations;

namespace AdministracionClientes.Models;

public class Company
{
    [Key] 
    public int Id { get; set; }

    [Required]
    [MaxLength(250)]
    public string Name { get; set; }

    public ICollection<Client> Clients { get; set; }
}