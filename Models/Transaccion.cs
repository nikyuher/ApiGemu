namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class Transaccion
{
    [Key]
    public int IdTransaccion { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    public decimal Cantidad { get; set; }
    public string? Nota { get; set; }
    public DateTime Fecha { get; set; }
    //Navegacion Usuario
    [JsonIgnore]
    public Usuario? Usuario { get; set; }
}
