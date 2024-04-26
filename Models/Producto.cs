namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Producto
{
    [Key]
    public int IdProducto { get; set; }
    [Required]
    public byte[]? ImgPortada { get; set; }
    [NotMapped]
    public List<byte[]> ImgsProducto { get; set; } = new List<byte[]>();
    [Required]
    public decimal Precio { get; set; }
    [Required]
    public string? Descripcion { get; set; }
    [Required]
    public string? Estado { get; set; }
    public int Cantidad { get; set; }


}