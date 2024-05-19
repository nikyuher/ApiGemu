using Gemu.Models;
using Microsoft.EntityFrameworkCore;

namespace Gemu.Data;
public class CarritoRepository : ICarritoRepository
{
    private readonly GemuContext _context;

    public CarritoRepository(GemuContext context)
    {
        _context = context;
    }

    public List<Carrito> GetAllCarritos()
    {
        var carritos = _context.Carritos.ToList();

        return carritos;
    }

    //Read
    public Carrito GetIdCarrito(int idCarrito)
    {
        var carrito = _context.Carritos.FirstOrDefault(r => r.IdCarrito == idCarrito);

        if (carrito is null)
        {
            throw new Exception($"No se encontro el Carrito con el ID: {idCarrito}");
        }

        return carrito;
    }

    public CarritoListaDTO GetCarritoUsuario(int idUsuario)
    {
        var carrito = _context.Carritos
        .Include(p => p.CarritoProductos)
        .ThenInclude(p => p.Producto)
        .ThenInclude(p => p.ImgsProducto)
        .Include(j => j.CarritoJuegos)
        .ThenInclude(j => j.Juego)
        .ThenInclude(j => j.ImgsJuego)
        .FirstOrDefault(r => r.IdUsuario == idUsuario);

        if (carrito is null)
        {
            throw new Exception($"No se encontro el Biblioteca del usuario con el ID: {idUsuario}");
        }

        var newCarrito = new CarritoListaDTO
        {
            IdUsuario = carrito.IdUsuario,
            CarritoProductos = carrito.CarritoProductos.ToList(),
            CarritoJuegos = carrito.CarritoJuegos.ToList(),
        };

        return newCarrito;
    }

    //Create
    public void CreateCarritoUsuario(CarritoDTO carrito)
    {
        var usuarioNew = new Carrito
        {
            IdUsuario = carrito.IdUsuario
        };

        _context.Carritos.Add(usuarioNew);
        SaveChanges();
    }

    public void AñadirJuegoCarrito(int idCarrito, int idJuego)
    {
        var existingJuego = _context.Juegos.FirstOrDefault(r => r.IdJuego == idJuego);

        if (existingJuego is null)
        {
            throw new Exception($"No se encontro el juego  con el ID: {idJuego}");
        }

        var existingCarrito = _context.Carritos.FirstOrDefault(r => r.IdCarrito == idCarrito);

        if (existingCarrito is null)
        {
            throw new Exception($"No se encontro la carrito  con el ID: {idCarrito}");
        }

        var newCarJuego = new CarritoJuego
        {
            CarritoId = existingCarrito.IdCarrito,
            JuegoId = existingJuego.IdJuego

        };

        existingCarrito.CarritoJuegos.Add(newCarJuego);
        SaveChanges();
    }

    public void AñadirProductoCarrito(int idCarrito, int idProducto)
    {
        var existingProducto = _context.Productos.FirstOrDefault(r => r.IdProducto == idProducto);

        if (existingProducto is null)
        {
            throw new Exception($"No se encontro el producto con el ID: {idProducto}");
        }

        var existingCarrito = _context.Carritos.FirstOrDefault(r => r.IdCarrito == idCarrito);

        if (existingCarrito is null)
        {
            throw new Exception($"No se encontro la carrito  con el ID: {idCarrito}");
        }

        var newCarProduct = new CarritoProducto
        {
            CarritoId = existingCarrito.IdCarrito,
            ProductoId = existingProducto.IdProducto

        };

        existingCarrito.CarritoProductos.Add(newCarProduct);
        SaveChanges();
    }

    //Update
    public void UpdateCarrito(Carrito carrito)
    {
        var existingCarrito = _context.Carritos.Find(carrito.IdCarrito);
        if (existingCarrito == null)
        {
            throw new KeyNotFoundException("No se encontró el Carrito a actualizar.");
        }

        _context.Entry(existingCarrito).CurrentValues.SetValues(carrito);
        SaveChanges();
    }

    //Delete
    public void DeleteCarrito(int idCarrito)
    {
        var carrito = GetIdCarrito(idCarrito);

        if (carrito is null)
        {
            throw new Exception($"No se encontro el Carrito con el ID: {idCarrito}");
        }

        _context.Carritos.Remove(carrito);
        SaveChanges();
    }

    public void EliminarJuegoCarrito(int idCarrito, int idJuego)
    {
        var existingJuego = _context.CarritoJuego.FirstOrDefault(r => r.CarritoJuegoId == idJuego);

        if (existingJuego is null)
        {
            throw new Exception($"No se encontro el juego  con el ID: {idJuego}");
        }

        var existingCarrito = _context.Carritos.FirstOrDefault(r => r.IdCarrito == idCarrito);

        if (existingCarrito is null)
        {
            throw new Exception($"No se encontro la carrito  con el ID: {idCarrito}");
        }

        existingCarrito.CarritoJuegos.Remove(existingJuego);

        SaveChanges();
    }

    public void EliminarProductoCarrito(int idCarrito, int idProducto)
    {
        var existingProducto = _context.CarritoProducto.FirstOrDefault(r => r.CarritoProductoId == idProducto);

        if (existingProducto is null)
        {
            throw new Exception($"No se encontro el producto con el ID: {idProducto}");
        }

        var existingCarrito = _context.Carritos.FirstOrDefault(r => r.IdCarrito == idCarrito);

        if (existingCarrito is null)
        {
            throw new Exception($"No se encontro la carrito  con el ID: {idCarrito}");
        }


        existingCarrito.CarritoProductos.Remove(existingProducto);

        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
