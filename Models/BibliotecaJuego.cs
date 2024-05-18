namespace Gemu.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
public class BibliotecaJuego
{
    public int BibliotecaJuegoId { get; set; }
    public int BibliotecaId { get; set; }
    [JsonIgnore]
    public Biblioteca? Biblioteca { get; set; }

    public int JuegoId { get; set; }
    public Juego? Juego { get; set; }

}
