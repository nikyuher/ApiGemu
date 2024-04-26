using Gemu.Models;

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

    //Create
    public void CreateCarrito(Carrito carrito)
    {
        _context.Carritos.Add(carrito);
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

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
