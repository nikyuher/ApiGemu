namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class ReseñaAddJuego
{
    [Key]
    public int IdReseña { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    [Required]
    public int IdJuego { get; set; }
    [Required]
    public string? Comentario { get; set; }
    [Required]
    public int Calificacion { get; set; }

}
