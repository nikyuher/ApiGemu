namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class ReseñaAddDTO
{
    [Key]
    public int IdReseña { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    [Required]
    public string? Comentario { get; set; }
    [Required]
    public int Calificacion { get; set; }

}
