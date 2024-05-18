namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class Producto
{
    [Key]
    public int IdProducto { get; set; }
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public decimal Precio { get; set; }
    [Required]
    public string? Descripcion { get; set; }
    public DateTime Fecha { get; set; }
    [Required]
    public string? Estado { get; set; }
    [Required]
    public int Cantidad { get; set; }
    public List<Imagen>? ImgsProducto { get; set; } = new List<Imagen>();
    public List<ProductoCategoria>? ProductoCategorias { get; set; } = new List<ProductoCategoria>();
    public List<Reseña>? Reseñas { get; set; } = new List<Reseña>();

    // Relación con Biblioteca
    [JsonIgnore]
    public List<BibliotecaProducto>? BibliotecaProductos { get; set; } = new List<BibliotecaProducto>();
    // Relación con Carrito
    [JsonIgnore]
    public List<CarritoProducto>? CarritoProductos { get; set; } = new List<CarritoProducto>();
    // Relación con Reseña
    [JsonIgnore]
    public int? IdReseña { get; set; }
    [JsonIgnore]
    public Reseña? Reseña { get; set; }
    // Relación con Anuncio
    [JsonIgnore]
    public int? IdAnuncio { get; set; }
    [JsonIgnore]
    public Anuncio? Anuncio { get; set; }


}