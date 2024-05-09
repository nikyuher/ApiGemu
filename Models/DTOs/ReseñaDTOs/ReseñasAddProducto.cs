namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class ReseñaAddProducto
{
    [Key]
    public int IdReseña { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    [Required]
    public int? IdProducto { get; set; }
    [Required]
    public string? Comentario { get; set; }
    [Required]
    public int Calificacion { get; set; }

}
