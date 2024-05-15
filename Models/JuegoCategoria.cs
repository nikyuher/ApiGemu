using System.Text.Json.Serialization;
namespace Gemu.Models

{
    public class JuegoCategoria
    {
        public int JuegoId { get; set; }
        [JsonIgnore]
        public Juego? Juego { get; set; }

        public int CategoriaId { get; set; }
        [JsonIgnore]
        public Categoria? Categoria { get; set; }
    }
}