namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class AprobarReseñaDTO
{
    [Key]
    public int IdReseña { get; set; }
    public string? Solicitud { get; set; }

}
