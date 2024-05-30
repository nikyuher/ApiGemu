using System.Text.Json.Serialization;
namespace Gemu.Models

{
    public class BibliotecaProducto
    {
        public int BibliotecaProductoId { get; set; }
        public int BibliotecaId { get; set; }
        [JsonIgnore]
        public Biblioteca? Biblioteca { get; set; }

        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}