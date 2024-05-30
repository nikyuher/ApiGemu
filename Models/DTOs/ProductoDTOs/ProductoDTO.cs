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
    public DateTime Fecha { get; set; }
    [Required]
    public string? Estado { get; set; }
    [Required]
    public int Cantidad { get; set; }
    public List<Reseña>? Reseñas { get; set; } = new List<Reseña>();

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