namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class UsuarioCreateDTO
{
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public string? Correo { get; set; }
    [Required]
    public string? Contraseña { get; set; }

}
