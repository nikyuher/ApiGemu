using System.Text.Json.Serialization;
namespace Gemu.Models

{
    public class CarritoJuego
    {
        public int CarritoJuegoId { get; set; }
        public int CarritoId { get; set; }
        [JsonIgnore]
        public Carrito? Carrito { get; set; }

        public int JuegoId { get; set; }
        public Juego? Juego { get; set; }
    }
}