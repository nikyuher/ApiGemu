namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class Producto
{
    [Key]
    public int IdProducto { get; set; }
    public List<Imagen> ImgsProducto { get; set; } = new List<Imagen>();
    [Required]
    public decimal Precio { get; set; }
    [Required]
    public string? Descripcion { get; set; }
    [Required]
    public string? Estado { get; set; }
    public int Cantidad { get; set; }


}