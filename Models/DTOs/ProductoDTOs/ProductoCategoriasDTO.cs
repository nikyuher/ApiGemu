namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class ProductoCategoriasDTO
{
    [Key]
    public int IdProducto { get; set; }
    [Required]
    public string? Nombre { get; set; }

    public List<ProductoCategoria>? ProductoCategorias { get; set; } = new List<ProductoCategoria>();
}