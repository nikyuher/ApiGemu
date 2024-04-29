namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class UsuarioFotoDTO
{
    [Key]
    public int IdUsuario { get; set; }
    public byte[]? FotoPerfil { get; set; }
}
