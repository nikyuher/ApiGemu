using System.Text.Json.Serialization;
namespace Gemu.Models
{
    public class ProductoCategoria
    {
        public int ProductoId { get; set; }
        [JsonIgnore]
        public Producto? Producto { get; set; }
        
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}