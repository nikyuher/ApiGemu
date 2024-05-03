namespace Gemu.Models;

using System.ComponentModel.DataAnnotations;
public class JuegoReseñaDTO
{
    [Key]
    public int IdJuego { get; set; }
    [Required]
    public string? Titulo { get; set; }

    public List<Reseña>? Reseñas { get; set; } = new List<Reseña>();

}