namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class Reseña
{
    [Key]
    public int IdReseña { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    [Required]
    public int IdProducto { get; set; }
    public string? Solicitud { get; set; }
    [Required]
    public string? Comentario { get; set; }
    [Required]
    public int Calificacion { get; set; }


}
