namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;

public class Rol
{
    [Key]
    public int IdRol { get; set; }
    
    [Required]
    public string? Nombre { get; set; }

    public List<Usuario>? Usuarios { get; set; } = new List<Usuario>();
}
