namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class UsuarioInfoDTO
{
    [Key]
    public int IdUsuario { get; set; }
    public string? Nombre { get; set; }
}
