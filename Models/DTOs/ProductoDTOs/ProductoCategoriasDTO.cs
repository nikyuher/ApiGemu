namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class ProductoCategoriasDTO
{
    [Key]
    public int IdProducto { get; set; }
    [Required]
    public string? Nombre { get; set; }

    public List<Categoria>? Categorias { get; set; } = new List<Categoria>();
}