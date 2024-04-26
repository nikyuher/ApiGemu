namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class Producto
{
    [Key]
    public int IdProducto { get; set; }
    [Required]
    public byte[]? ImgPortada { get; set; }
    public List<byte[]> ImgsProducto { get; set; } = new List<byte[]>();
    [Required]
    public decimal Precio { get; set; }
    [Required]
    public string? Descripcion { get; set; }
    [Required]
    public string? Estado { get; set; }
    public int Cantidad { get; set; }


}