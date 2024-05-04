namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class ProductoDTO
{
    [Key]
    public int IdProducto { get; set; }
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public decimal Precio { get; set; }
    [Required]
    public string? Descripcion { get; set; }
    [Required]
    public string? Estado { get; set; }
    [Required]
    public int Cantidad { get; set; }

}