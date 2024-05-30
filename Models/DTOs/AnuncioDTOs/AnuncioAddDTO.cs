namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class AnuncioAddDTO
{
    [Key]
    public int IdAnuncio { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    [Required]
    public int IdProducto { get; set; }
}