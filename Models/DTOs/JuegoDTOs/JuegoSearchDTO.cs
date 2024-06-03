namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class JuegoSearchDTO
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
    public List<Imagen>? ImgsJuego { get; set; } = new List<Imagen>();
    public DateTime Fecha { get; set; }

}