using Gemu.Models;

namespace Gemu.Data;
public interface IProductoRepository
{
    //Read
    public List<Producto> GetAllProductos();
    public Producto GetIdProducto(int idProducto);
    public ProductoCategoriasDTO GetCategoriasProduct(int idProducto);
    public ProductoReseñaDTO GetReseñasProducto(int idProducto);
    //Create
    void CreateProducto(ProductoAddDTO producto);
    void AsignarCategoriasProducto(int idProducto, List<int> ListaIdsCateogira);
    //Update
    void UpdateProducto(ProductoDTO producto);
    void UpdateCategoriasProducto(int idProducto, List<Categoria> ListaCategoria);
    //Delete
    void DeleteProducto(int idProducto);
    void EliminarCategoriasProducto(int idProducto, List<int> ListaIdsCateogira);
}   