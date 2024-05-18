namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class BibliotecaListaDTO
{

    [Key]
    public int IdBiblioteca { get; set; }
    public int IdUsuario { get; set; }
    public List<BibliotecaProducto>? BibliotecaProductos { get; set; } = new List<BibliotecaProducto>();
    public List<BibliotecaJuego>? BibliotecaJuegos { get; set; } = new List<BibliotecaJuego>();

}
