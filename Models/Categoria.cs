namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class Categoria
{
    [Key]
    public int IdCategoria { get; set; }
    [Required]
    public string? Nombre { get; set; }
    public string? Icono {get; set; }
    public string? Seccion { get; set; }
    [JsonIgnore]
    public List<ProductoCategoria>? ProductoCategorias { get; set; } = new List<ProductoCategoria>();
    [JsonIgnore]
    public List<JuegoCategoria>? JuegoCategorias { get; set; } = new List<JuegoCategoria>();

}
