namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class Biblioteca
{
    [Key]
    public int IdBiblioteca { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    [JsonIgnore]
    public Usuario? Usuario { get; set; }
    public List<BibliotecaProducto>? BibliotecaProductos { get; set; } = new List<BibliotecaProducto>();
    public List<BibliotecaJuego>? BibliotecaJuegos { get; set; } = new List<BibliotecaJuego>();

}
