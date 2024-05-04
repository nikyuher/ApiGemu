namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class BibliotecaListaDTO
{

    [Key]
    public int IdBiblioteca { get; set; }
    public int IdUsuario { get; set; }
    public List<ProductoBibliotecaDTO>? Productos { get; set; } = new List<ProductoBibliotecaDTO>();
    public List<JuegoBiliotecaDTO>? Juegos { get; set; } = new List<JuegoBiliotecaDTO>();

}
