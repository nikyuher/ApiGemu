namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class UsuarioDireccionDTO
{
    [Key]
    public int IdUsuario { get; set; }
    public string? Direccion { get; set; }
    public int CodigoPostal { get; set; }
}
