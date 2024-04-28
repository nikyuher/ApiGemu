namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;

public class RolUpdateNombreDTO
{
    [Key]
    public int IdRol { get; set; }
    
    [Required]
    public string? Nombre { get; set; }
}
