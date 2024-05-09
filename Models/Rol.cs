namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Rol
{
    [Key]
    public int IdRol { get; set; }

    [Required]
    public string? Nombre { get; set; }
    [JsonIgnore]
    public List<Usuario>? Usuarios { get; set; } = new List<Usuario>();
}
