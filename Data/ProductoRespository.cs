using Gemu.Models;

namespace Gemu.Data;
public class ProductoRepository : IProductoRepository
{
    private readonly GemuContext _context;

    public ProductoRepository(GemuContext context)
    {
        _context = context;
    }

        public List<Producto> GetAllProductos()
    {
        var productos = _context.Productos.ToList();

        return productos;
    }

    //Read
    public Producto GetIdProducto(int idProducto)
    {
        var producto = _context.Productos.FirstOrDefault(r => r.IdProducto == idProducto);

        if (producto is null)
        {
            throw new Exception($"No se encontro el Producto con el ID: {idProducto}");
        }

        return producto;
    }

    //Create
    public void CreateProducto(Producto producto)
    {
        _context.Productos.Add(producto);
        SaveChanges();
    }

    //Update
    public void UpdateProducto(Producto producto)
    {
        var existingProducto = _context.Juegos.Find(producto.IdProducto);
        if (existingProducto == null)
        {
            throw new KeyNotFoundException("No se encontró el Producto a actualizar.");
        }

        _context.Entry(existingProducto).CurrentValues.SetValues(producto);
        SaveChanges();
    }

    //Delete
    public void DeleteProducto(int idProducto)
    {
        var producto = GetIdProducto(idProducto);

        if (producto is null)
        {
            throw new Exception($"No se encontro el Producto con el ID: {idProducto}");
        }

        _context.Productos.Remove(producto);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
