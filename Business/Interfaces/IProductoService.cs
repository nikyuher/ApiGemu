using Gemu.Models;

namespace Gemu.Data;
public interface IProductoService
{
    //Read
    public List<Producto> GetAllProductos();
    public Producto GetIdProducto(int idProducto);
    public ProductoCategoriasDTO GetCategoriasProduct(int idProducto);
    public ProductoReseñaDTO GetReseñasProducto(int idProducto);
    //Create
    public Producto CreateProducto(ProductoAddDTO producto);
    void AsignarCategoriasProducto(int idProducto, List<int> ListaIdsCateogira);
    //Update
    void UpdateProducto(ProductoDTO producto);
    //Delete
    void DeleteProducto(int idProducto);
    void EliminarCategoriasProducto(int idProducto, List<int> ListaIdsCateogira);
}