namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class Juego
{
    [Key]
    public int IdJuego { get; set; }
    [Required]
    public byte[]? ImgPortada { get; set; }
    public List<byte[]> ImgsJuego { get; set; } = new List<byte[]>();
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
    [Required]
    public List<string>? Categorias = new List<string>();
    public int? Descuento { get; set; }
    public string? CodigoJuego { get; set; }
    public List<Reseña> Reseñas { get; set; } = new List<Reseña>();
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