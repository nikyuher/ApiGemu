namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class Anuncio
{
    [Key]
    public int IdAnuncio { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    [Required]
    public int IdProducto { get; set; }
    public Producto? Producto { get; set; }
}