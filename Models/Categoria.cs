namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class Categoria
{
    [Key]
    public int IdCategoria { get; set; }
    [Required]
    public string? Nombre { get; set; }

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

}
