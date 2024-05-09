namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class JuegoDTO
{
    [Key]
    public int IdJuego { get; set; }
    [Required]
    public string? Titulo { get; set; }
    [Required]
    public string? Descripcion { get; set; }
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
    public DateTime Fecha { get; set; }
    
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

}