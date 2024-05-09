namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class UsuarioDTO
{
    [Key]
    public int IdUsuario { get; set; }
    [Required]
    public int IdRol { get; set; }
    public string? Rol {get; set; }
    public byte[]? FotoPerfil { get; set; }
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public string? Correo { get; set; }
    [Required]
    public string? Direccion { get; set; }
    public int CodigoPostal { get; set; }
    public decimal SaldoActual {get; set;}

}
