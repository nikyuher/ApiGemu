namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;

public class RolCreateDTO
{
    [Key]
    public int IdRol { get; set; }
    
    [Required]
    public string? Nombre { get; set; }

}
