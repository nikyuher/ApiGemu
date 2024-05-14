using Gemu.Models;
using Microsoft.EntityFrameworkCore;

namespace Gemu.Data;
public class ProductoRepository : IProductoRepository
{
    private readonly GemuContext _context;

    public ProductoRepository(GemuContext context)
    {
        _context = context;
    }

    //Read
    public List<Producto> GetAllProductos()
    {
        var productos = _context.Productos.Include(r => r.Categorias).ToList();

        return productos;
    }

    public Producto GetIdProducto(int idProducto)
    {
        var producto = _context.Productos.Include(r => r.Categorias).FirstOrDefault(r => r.IdProducto == idProducto);

        if (producto is null)
        {
            throw new Exception($"No se encontro el Producto con el ID: {idProducto}");
        }

        return producto;
    }

    public ProductoCategoriasDTO GetCategoriasProduct(int idProducto)
    {

        var producto = _context.Productos.Include(r => r.Categorias).FirstOrDefault(r => r.IdProducto == idProducto);

        if (producto is null)
        {
            throw new Exception($"No se encontro el Producto con el ID: {idProducto}");
        }

        var newProducto = new ProductoCategoriasDTO
        {
            IdProducto = producto.IdProducto,
            Nombre = producto.Nombre,
            Categorias = producto.Categorias
        };

        return newProducto;
    }

    public ProductoReseñaDTO GetReseñasProducto(int idProducto)
    {

        var producto = _context.Productos.Include(r => r.Reseñas).FirstOrDefault(r => r.IdProducto == idProducto);

        if (producto is null)
        {
            throw new Exception($"No se encontro el Producto con el ID: {idProducto}");
        }

        var newProducto = new ProductoReseñaDTO
        {
            IdProducto = producto.IdProducto,
            Nombre = producto.Nombre,
            Reseñas = producto.Reseñas
        };

        return newProducto;
    }

    //Create
    public Producto CreateProducto(ProductoAddDTO producto)
    {
        var newProducto = new Producto
        {
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Descripcion = producto.Descripcion,
            Estado = producto.Estado,
            Cantidad = producto.Cantidad,
            Fecha = DateTime.Today
        };

        _context.Productos.Add(newProducto);
        SaveChanges();
        
        return newProducto;
    }

    public void AsignarCategoriasProducto(int idProducto, List<int> ListaIdsCateogira)
    {

        foreach (var item in ListaIdsCateogira)
        {
            var categoria = _context.Categorias.FirstOrDefault(r => r.IdCategoria == item);

            if (categoria is null)
            {
                throw new Exception($"No se encontro la categoria con el ID: {item}");
            }

            var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);

            if (producto is null)
            {
                throw new Exception($"No se encontro el producto con el ID: {idProducto}");
            }

            producto.Categorias.Add(categoria);

        }
        SaveChanges();
    }


    //Update
    public void UpdateProducto(ProductoDTO producto)
    {
        var existingProducto = _context.Productos.Find(producto.IdProducto);
        if (existingProducto == null)
        {
            throw new KeyNotFoundException("No se encontró el Producto a actualizar.");
        }

        existingProducto.Nombre = producto.Nombre;
        existingProducto.Precio = producto.Precio;
        existingProducto.Descripcion = producto.Descripcion;
        existingProducto.Cantidad = producto.Cantidad;
        existingProducto.Estado = producto.Estado;

        _context.Productos.Update(existingProducto);
        SaveChanges();
    }


    public void UpdateCategoriasProducto(int idProducto, List<Categoria> ListaCategoria)
    {

        var Categorias = _context.Productos.FirstOrDefault(r => r.IdProducto == idProducto);

        if (Categorias is null)
        {
            throw new Exception($"No se encontro el Producto con el id {idProducto}");
        }

        Categorias.Categorias.Clear();
        Categorias.Categorias.AddRange(ListaCategoria);
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

    public void EliminarCategoriasProducto(int idProducto, List<int> ListaIdsCateogira)
    {

        foreach (var item in ListaIdsCateogira)
        {
            var categoria = _context.Categorias.FirstOrDefault(r => r.IdProducto == item);

            if (categoria is null)
            {
                throw new Exception($"No se encontro la categoria con el ID: {item}");
            }

            var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);

            if (producto is null)
            {
                throw new Exception($"No se encontro el producto con el ID: {idProducto}");
            }

            producto.Categorias.Remove(categoria);

        }
        SaveChanges();

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
