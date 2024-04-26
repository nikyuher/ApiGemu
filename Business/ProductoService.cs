using Gemu.Data;
using Gemu.Models;

namespace Gemu.Business;
public class ProductoService : IProductoService
{
    private readonly IProductoRepository _productoRepository;

    public ProductoService(IProductoRepository repository)
    {
        _productoRepository = repository;
    }

    public List<Producto> GetAllProductos()
    {
        return _productoRepository.GetAllProductos();
    }
    public Producto GetIdProducto(int idProducto)
    {
        return _productoRepository.GetIdProducto(idProducto);
    }
    public void CreateProducto(Producto producto)
    {
        _productoRepository.CreateProducto(producto);
    }
    public void UpdateProducto(Producto producto)
    {
        _productoRepository.UpdateProducto(producto);
    }
    public void DeleteProducto(int idProducto)
    {
        _productoRepository.DeleteProducto(idProducto);
    }
}
