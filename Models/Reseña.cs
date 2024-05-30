namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class Reseña
{
    [Key]
    public int IdReseña { get; set; }
    [Required]
    public int IdUsuario { get; set; }
    public string? NombreUsuario { get; set; }
    public string? Solicitud { get; set; }
    [Required]
    public string? Comentario { get; set; }
    [Required]
    public int Calificacion { get; set; }
    public DateTime Fecha { get; set; }

    //Relacion Juego
    [JsonIgnore]
    public int? IdJuego { get; set; }
    [JsonIgnore]
    public Juego? Juego { get; set; }
    //Relacion Producto
    [JsonIgnore]
    public int? IdProducto { get; set; }
    [JsonIgnore]
    public Producto? Producto { get; set; }

    //Navegacion
    [JsonIgnore]
    public Usuario? Usuario { get; set; }
}
