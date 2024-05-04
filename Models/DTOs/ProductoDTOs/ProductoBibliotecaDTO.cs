namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class ProductoBibliotecaDTO
{
    [Key]
    public int IdProducto { get; set; }
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public decimal Precio { get; set; }
    [Required]
    public string? Estado { get; set; }
    public List<Imagen>? ImgsProducto { get; set; } = new List<Imagen>();
    public List<Categoria>? Categorias { get; set; } = new List<Categoria>();
}