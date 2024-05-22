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


    //Read
    public List<Producto> GetAllProductos()
    {
        return _productoRepository.GetAllProductos();
    }
    public List<Producto>  GetProductoPaginados(int pageNumber, int pageSize)
    {
        return _productoRepository.GetProductoPaginados(pageNumber, pageSize);
    }
    public List<Producto> GetProductoPaginadosCategoria(int pageNumber, int pageSize, List<int> categoriaIds)
    {
        return _productoRepository.GetProductoPaginadosCategoria(pageNumber,pageSize,categoriaIds);
    }
    public ProductoDTO GetIdProducto(int idProducto)
    {
        return _productoRepository.GetIdProducto(idProducto);
    }
    public ProductoCategoriasDTO GetCategoriasProduct(int idProducto)
    {
        return _productoRepository.GetCategoriasProduct(idProducto);
    }
    public ProductoReseñaDTO GetReseñasProducto(int idProducto)
    {
        return _productoRepository.GetReseñasProducto(idProducto);
    }
    //Create
    public Producto CreateProducto(ProductoAddDTO producto)
    {
       return _productoRepository.CreateProducto(producto);
    }
    public void AsignarCategoriasProducto(int idProducto, List<int> ListaIdsCateogira)
    {
        _productoRepository.AsignarCategoriasProducto(idProducto, ListaIdsCateogira);
    }
    //Update
    public void UpdateProducto(ProductoDTO producto)
    {
        _productoRepository.UpdateProducto(producto);
    }

    //Delete
    public void DeleteProducto(int idProducto)
    {
        _productoRepository.DeleteProducto(idProducto);
    }

}
