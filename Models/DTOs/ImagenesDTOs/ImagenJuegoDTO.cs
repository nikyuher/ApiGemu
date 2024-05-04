namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ImagenJuegoDTO
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public byte[]? Datos { get; set; }
    
    public bool EsPortada { get; set; }
    public int? JuegoId { get; set; }
    [JsonIgnore]
    public Juego? Juego { get; set; }

}
