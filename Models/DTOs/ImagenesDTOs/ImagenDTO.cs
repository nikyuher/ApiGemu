namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class ImagenDTO
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public byte[]? Datos { get; set; }
    
    public bool EsPortada { get; set; }

}
