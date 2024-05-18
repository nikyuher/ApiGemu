namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class CarritoListaDTO
{
    [Key]
    public int IdCarrito { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    public List<CarritoProducto>? CarritoProductos { get; set; } = new List<CarritoProducto>();
    public List<CarritoJuego>? CarritoJuegos { get; set; } = new List<CarritoJuego>();


}
