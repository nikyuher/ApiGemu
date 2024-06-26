using Gemu.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq.Expressions;

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
        var productos = _context.Productos.Include(img => img.ImgsProducto).Include(r => r.ProductoCategorias).ToList();

        var nuevosProductos = new List<Producto>();

        foreach (var producto in productos)
        {
            var nuevoProducto = new Producto
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Fecha = producto.Fecha,
                Precio = producto.Precio,
                Estado = producto.Estado,
                ImgsProducto = producto.ImgsProducto.Take(1).ToList(),
                ProductoCategorias = producto.ProductoCategorias
            };

            nuevosProductos.Add(nuevoProducto);
        }

        return nuevosProductos;
    }


    public async Task<IEnumerable<ProductoSearchDTO>> ProductoSearch(string Nombre)
    {
        var producto = await  _context.Productos.Include(j => j.ImgsProducto).Where(j => j.Nombre.Contains(Nombre)).ToListAsync();

        var productoSearchList = producto.Select(j => new ProductoSearchDTO
        {
            IdProducto = j.IdProducto,
            Nombre = j.Nombre,
            Precio = j.Precio,
            Estado = j.Estado,
            ImgsProducto = j.ImgsProducto.Take(1).ToList()
        }).ToList();

        return  productoSearchList;    
    }

    public List<Producto> GetProductoPaginados(int pageNumber, int pageSize)
    {
        return GetFilteredProductos(pageNumber, pageSize).ToList();
    }

    public List<Producto> GetProductoPaginadosCategoria(int pageNumber, int pageSize, List<int> categoriaIds)
    {
        return GetFilteredProductos(pageNumber, pageSize, null, categoriaIds).ToList();
    }

    public ProductoDTO GetIdProducto(int idProducto)
    {
        var producto = _context.Productos
                        .Include(c => c.Reseñas)
                        .FirstOrDefault(r => r.IdProducto == idProducto);

        if (producto is null)
        {
            throw new Exception($"No se encontro el Producto con el ID: {idProducto}");
        }


        var newProducto = new ProductoDTO
        {
            IdProducto = producto.IdProducto,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Descripcion = producto.Descripcion,
            Fecha = producto.Fecha,
            Estado = producto.Estado,
            Cantidad = producto.Cantidad,
            Reseñas = producto.Reseñas
        };

        return newProducto;
    }

    public ProductoCategoriasDTO GetCategoriasProduct(int idProducto)
    {

        var producto = _context.Productos
                       .Include(r => r.ProductoCategorias)
                       .ThenInclude(r => r.Categoria)
                       .FirstOrDefault(r => r.IdProducto == idProducto);

        if (producto is null)
        {
            throw new Exception($"No se encontro el Producto con el ID: {idProducto}");
        }

        var newProducto = new ProductoCategoriasDTO
        {
            IdProducto = producto.IdProducto,
            Nombre = producto.Nombre,
            ProductoCategorias = producto.ProductoCategorias
        };

        return newProducto;
    }

    public ProductoReseñaDTO GetReseñasProducto(int idProducto)
    {

        var producto = _context.Productos
                        .Include(r => r.Reseñas)
                        .FirstOrDefault(r => r.IdProducto == idProducto);

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
            Fecha = DateTime.Now
        };

        _context.Productos.Add(newProducto);
        SaveChanges();

        return newProducto;
    }

    public void AsignarCategoriasProducto(int idProducto, List<int> ListaIdsCateogira)
    {

        var producto = _context.Productos.Include(j => j.ProductoCategorias).FirstOrDefault(p => p.IdProducto == idProducto);

        if (producto is null)
        {
            throw new Exception($"No se encontro el producto con el ID: {idProducto}");
        }

        producto.ProductoCategorias.Clear();

        foreach (var item in ListaIdsCateogira)
        {
            var categoria = _context.Categorias.FirstOrDefault(r => r.IdCategoria == item);

            if (categoria is null)
            {
                throw new Exception($"No se encontro la categoria con el ID: {item}");
            }


            var newCategoria = new ProductoCategoria
            {
                ProductoId = producto.IdProducto,
                CategoriaId = categoria.IdCategoria
            };

            producto.ProductoCategorias.Add(newCategoria);

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


    //Delete
    public void DeleteProducto(int idProducto)
    {
        var producto = _context.Productos.FirstOrDefault(p => p.IdProducto == idProducto);

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

    private IQueryable<Producto> GetFilteredProductos(int pageNumber, int pageSize, Expression<Func<Producto, bool>> filtro = null, List<int> categoriaIds = null)
    {
        var query = _context.Productos
                            .Include(j => j.ImgsProducto)
                            .Include(j => j.ProductoCategorias)
                                .ThenInclude(jc => jc.Categoria)
                            .AsQueryable();

        if (filtro != null)
        {
            query = query.Where(filtro);
        }

        if (categoriaIds != null && categoriaIds.Any())
        {
            query = query
                    .Where(j => j.ProductoCategorias
                    .Count(jc => categoriaIds
                    .Contains(jc.CategoriaId)) == categoriaIds.Count);
        }

        var pagedProducto = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        var productoConPrimeraImagen = pagedProducto.Select(j => new Producto
        {
            IdProducto = j.IdProducto,
            Nombre = j.Nombre,
            Descripcion = j.Descripcion,
            Fecha = j.Fecha,
            Precio = j.Precio,
            Estado = j.Estado,
            ImgsProducto = j.ImgsProducto.Take(1).ToList(),
            ProductoCategorias = j.ProductoCategorias
        });

        return productoConPrimeraImagen;
    }
}
