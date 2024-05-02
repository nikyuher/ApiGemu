namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class ProductoReseñaDTO
{
    [Key]
    public int IdProducto { get; set; }
    [Required]
    public string? Nombre { get; set; }

    public List<Reseña>? Reseñas { get; set; } = new List<Reseña>();
}