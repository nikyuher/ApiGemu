namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class AnuncioDTO
{
    [Key]
    public int IdAnuncio { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    public DateTime Fecha { get; set; }
    public ProductoBibliotecaDTO? Producto { get; set; }
}