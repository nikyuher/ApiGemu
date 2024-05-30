namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class Anuncio
{
    [Key]
    public int IdAnuncio { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    public DateTime Fecha { get; set; }
    //Navegacion Usuario
    [JsonIgnore]
    public Usuario? Usuario { get; set; }
    [Required]
    public int IdProducto { get; set; }
    public Producto? Producto { get; set; }
}