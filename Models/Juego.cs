namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class Juego
{
    [Key]
    public int IdJuego { get; set; }
    [Required]
    public string? Titulo { get; set; }
    [Required]
    public decimal Precio { get; set; }
    public decimal PrecioFinal
    {
        get
        {
            if (Descuento.HasValue && Descuento > 0)
            {
                return Precio * (1 - (Descuento.Value / 100m));
            }
            return Precio;
        }
    }
    [Required]
    public string? Plataforma { get; set; }
    public int? Descuento { get; set; }
    [Required]
    public string? CodigoJuego { get; set; }
    public List<Imagen>? ImgsJuego { get; set; } = new List<Imagen>();
    public List<Reseña>? Reseñas { get; set; } = new List<Reseña>();
    public List<Categoria>? Categorias = new List<Categoria>();
    public double CalificacionPromedio
    {
        get
        {
            if (Reseñas == null || Reseñas.Count == 0)
            {
                return 0.0;
            }

            double promedio = Reseñas.Average(r => r.Calificacion);
            return promedio;
        }
    }

    // Relación con Biblioteca
    [JsonIgnore]
    public int? IdBiblioteca { get; set; }
    [JsonIgnore]
    public Biblioteca? Biblioteca { get; set; }
    // Relación con Carrito
    [JsonIgnore]
    public int? IdCarrito { get; set; }
    [JsonIgnore]
    public Carrito? Carrito { get; set; }
    // Relación con Reseña
    [JsonIgnore]
    public int? IdReseña { get; set; }
    [JsonIgnore]
    public Reseña? Reseña { get; set; }
    // Relación con Imagenes
    [JsonIgnore]
    public int? IdImagen { get; set; }
    [JsonIgnore]
    public Imagen? Imagen { get; set; }
    // Relación con Categoria
    [JsonIgnore]
    public int? IdCategoria { get; set; }
    [JsonIgnore]
    public Categoria? Categoria { get; set; }
}