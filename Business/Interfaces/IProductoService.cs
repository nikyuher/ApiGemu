using Gemu.Models;

namespace Gemu.Data;
public interface IProductoService
{
    //Read
    public List<Producto> GetAllProductos();
    public Task<IEnumerable<ProductoSearchDTO>> ProductoSearch(string Nombre);
    public List<Producto> GetProductoPaginados(int pageNumber, int pageSize);
    public List<Producto> GetProductoPaginadosCategoria(int pageNumber, int pageSize, List<int> categoriaIds);
    public ProductoDTO GetIdProducto(int idProducto);
    public ProductoCategoriasDTO GetCategoriasProduct(int idProducto);
    public ProductoReseñaDTO GetReseñasProducto(int idProducto);
    //Create
    public Producto CreateProducto(ProductoAddDTO producto);
    void AsignarCategoriasProducto(int idProducto, List<int> ListaIdsCateogira);
    //Update
    void UpdateProducto(ProductoDTO producto);
    //Delete
    void DeleteProducto(int idProducto);
}