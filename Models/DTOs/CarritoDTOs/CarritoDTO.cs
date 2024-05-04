namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class CarritoDTO
{
    [Key]
    public int IdCarrito { get; set; }
    [Required]
    public int IdUsuario { get; set; }



}
