namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class BibliotecaDTO
{
    [Key]
    public int IdBiblioteca { get; set; }
    [Required]
    public int IdUsuario { get; set; }

}
