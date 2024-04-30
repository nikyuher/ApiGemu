namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;

public class Imagen
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public byte[]? Datos { get; set; }
    
    public bool EsPortada { get; set; }
    
    public int? JuegoId { get; set; }
    public Juego? Juego { get; set; }
    
    public int? ProductoId { get; set; }
    public Producto? Producto { get; set; }
}
