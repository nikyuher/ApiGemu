namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class JuegoBiliotecaDTO
{
    [Key]
    public int IdJuego { get; set; }
    [Required]
    public string? Titulo { get; set; }
    [Required]
    public decimal Precio { get; set; }

    [Required]
    public string? CodigoJuego { get; set; }
    public List<Imagen>? ImgsJuego { get; set; } = new List<Imagen>();
     public List<JuegoCategoria>? JuegoCategorias { get; set; } = new List<JuegoCategoria>();



}