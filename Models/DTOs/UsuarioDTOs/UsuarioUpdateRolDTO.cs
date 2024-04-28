namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class UsuarioUpdateDTO
{
    [Key]
    public int IdUsuario { get; set; }
    [Required]
    public int IdRol { get; set; }

}
