using System.Text.Json.Serialization;
namespace Gemu.Models

{
    public class CarritoProducto
    {
        public int CarritoProductoId { get; set; }
        public int CarritoId { get; set; }
        [JsonIgnore]
        public Carrito? Carrito { get; set; }

        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}