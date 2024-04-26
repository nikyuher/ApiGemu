namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class Carrito
{
    [Key]
    public int IdCarrito { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    public int IdProducto { get; set; }
    public Producto? Productos { get; set; }


}
