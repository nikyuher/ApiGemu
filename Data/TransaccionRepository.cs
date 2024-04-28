using Gemu.Models;

namespace Gemu.Data;
public class TransaccionRepository : ITransaccionRepository
{
    private readonly GemuContext _context;

    public TransaccionRepository(GemuContext context)
    {
        _context = context;
    }
    public List<Transaccion> GetAllTransacciones()
    {
        var transacciones = _context.Transacciones.ToList();

        return transacciones;
    }

    //Read
    public Transaccion GetIdTransaccion(int idTransaccion)
    {
        var transaccion = _context.Transacciones.FirstOrDefault(r => r.IdTransaccion == idTransaccion);

        if (transaccion is null)
        {
            throw new Exception($"No se encontro el Transaccion con el ID: {idTransaccion}");
        }

        return transaccion;
    }

    //Create
    public void CreateTransaccion(Transaccion transaccion)
    {

        var usuario = _context.Usuarios.Find(transaccion.IdUsuario);
        if (usuario == null)
        {
            throw new KeyNotFoundException("No se encontró el usuario asociado con la transacción.");
        }
        usuario.SaldoActual += transaccion.Cantidad;

        transaccion.Total = usuario.SaldoActual;

        _context.Transacciones.Add(transaccion);
        SaveChanges();
    }

    //Update
    public void UpdateTransaccion(Transaccion transaccion)
    {
        var existingTransaccion = _context.Transacciones.Find(transaccion.IdTransaccion);
        if (existingTransaccion == null)
        {
            throw new KeyNotFoundException("No se encontró el Transaccion a actualizar.");
        }

        _context.Entry(existingTransaccion).CurrentValues.SetValues(transaccion);
        SaveChanges();
    }

    //Delete
    public void DeleteTransaccion(int idTransaccion)
    {
        var transaccion = GetIdTransaccion(idTransaccion);

        if (transaccion is null)
        {
            throw new Exception($"No se encontro el Transaccion con el ID: {idTransaccion}");
        }

        _context.Transacciones.Remove(transaccion);
        SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}
