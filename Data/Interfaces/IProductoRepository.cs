using Gemu.Models;

namespace Gemu.Data;
public interface IProductoRepository
{
    public List<Producto> GetAllProductos();
    public Producto GetIdProducto(int idProducto);
    void CreateProducto(Producto producto);
    void UpdateProducto(Producto producto);
    void DeleteProducto(int idProducto);
}   