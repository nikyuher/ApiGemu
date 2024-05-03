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
    public void CreateProducto(ProductoAddDTO producto)
    {
        var newProducto = new Producto
        {
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Descripcion = producto.Descripcion,
            Estado = producto.Estado,
            Cantidad = producto.Cantidad,
            ImgsProducto = producto.ImgsProducto,
            Categorias = producto.Categorias
        };

        _context.Productos.Add(newProducto);
        SaveChanges();
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

    public void AsignarReseñaProducto(int idProducto, List<int> ListaIdsReseñas)
    {
        foreach (var item in ListaIdsReseñas)
        {
            var reseña = _context.Reseñas.FirstOrDefault(r => r.IdReseña == item);

            if (reseña is null)
            {
                throw new Exception($"No se encontro la reseña con el ID: {item}");
            }

            var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);

            if (producto is null)
            {
                throw new Exception($"No se encontro el producto con el ID: {idProducto}");
            }

            producto.Reseñas.Add(reseña);

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

    public void UpdateImgsProducto(int idProducto, List<Imagen> ListaImgs)
    {

        var Imagenes = _context.Productos.FirstOrDefault(r => r.IdProducto == idProducto);

        if (Imagenes is null)
        {
            throw new Exception($"No se encontro el Producto con el id {idProducto}");
        }


        Imagenes.ImgsProducto.Clear();
        Imagenes.ImgsProducto.AddRange(ListaImgs);
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

    public void UpdateReseñaProducto(int idProducto, List<Reseña> ListaCategoria)
    {

        var Categorias = _context.Productos.FirstOrDefault(r => r.IdProducto == idProducto);

        if (Categorias is null)
        {
            throw new Exception($"No se encontro el Producto con el id {idProducto}");
        }

        Categorias.Reseñas.Clear();
        Categorias.Reseñas.AddRange(ListaCategoria);
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


    public void EliminarImgsProducto(int idProducto, List<int> ListaIdsImagenes)
    {

        foreach (var item in ListaIdsImagenes)
        {
            var reseña = _context.Imagenes.FirstOrDefault(r => r.Id == item);

            if (reseña is null)
            {
                throw new Exception($"No se encontro la imagen con el ID: {item}");
            }

            var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);

            if (producto is null)
            {
                throw new Exception($"No se encontro el producto con el ID: {idProducto}");
            }

            producto.ImgsProducto.Remove(reseña);

        }

        SaveChanges();

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
