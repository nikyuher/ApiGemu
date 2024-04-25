namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
public class Transaccion
{
    [Key]
    public int IdTransaccion { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    public decimal Cantidad { get; set; }
    public string? Nota { get; set; }
    public DateTime Fecha { get; set; }

}
