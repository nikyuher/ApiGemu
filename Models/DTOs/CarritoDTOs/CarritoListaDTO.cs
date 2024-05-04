namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class CarritoListaDTO
{
    [Key]
    public int IdCarrito { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    public List<ProductoBibliotecaDTO>? Productos { get; set; } = new List<ProductoBibliotecaDTO>();
    public List<JuegoBiliotecaDTO>? Juegos { get; set; } = new List<JuegoBiliotecaDTO>();


}
