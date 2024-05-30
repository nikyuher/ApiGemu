namespace Gemu.Models;

using System.ComponentModel.DataAnnotations;
public class JuegoCategoriasDTO
{
    [Key]
    public int IdJuego { get; set; }
    [Required]
    public string? Titulo { get; set; }

    public List<JuegoCategoria>? JuegoCategorias { get; set; } = new List<JuegoCategoria>();

}