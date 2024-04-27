namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class Carrito
{
    [Key]
    public int IdCarrito { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    [JsonIgnore]
    public Usuario? Usuario { get; set; }
    public List<Producto>? Productos { get; set; } = new List<Producto>();
    public List<Juego>? Juegos { get; set; } = new List<Juego>();


}
