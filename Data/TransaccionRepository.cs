using Gemu.Models;

namespace Gemu.Data;
public class TransaccionRepository : ITransaccionRepository
{
    private readonly GemuContext _context;

    public TransaccionRepository(GemuContext context)
    {
        _context = context;
    }

    //Read
    public List<TransaccionDTO> GetAllTransacciones()
    {
        var transacciones = _context.Transacciones.ToList();

        var newTransacciones = transacciones.Select(transaccion => new TransaccionDTO
        {
            IdTransaccion = transaccion.IdTransaccion,
            IdUsuario = transaccion.IdUsuario,
            Total = transaccion.Total,
            Cantidad = transaccion.Cantidad,
            Nota = transaccion.Nota,
            Fecha = transaccion.Fecha
        }).ToList();

        return newTransacciones;
    }
    public Transaccion GetIdTransaccion(int idTransaccion)
    {
        var transaccion = _context.Transacciones.FirstOrDefault(r => r.IdTransaccion == idTransaccion);

        if (transaccion is null)
        {
            throw new Exception($"No se encontro el Transaccion con el ID: {idTransaccion}");
        }

        return transaccion;
    }

    public List<Transaccion> GetTransaccionesUsuario(int idUsuario)
    {
        var transacciones = _context.Transacciones.Where(r => r.IdUsuario == idUsuario).ToList();

        if (transacciones is null)
        {
            throw new Exception($"No se encontro el Transaccion del usuario con el ID: {idUsuario}");
        }

        return transacciones;

    }

    //Create
    public void AñadirCantidadTransaccion(Transaccion transaccion)
    {

        var usuario = _context.Usuarios.Find(transaccion.IdUsuario);
        if (usuario == null)
        {
            throw new KeyNotFoundException("No se encontró el usuario asociado con la transacción.");
        }

        if (transaccion.Cantidad <= 0)
        {
            throw new Exception("No se pueden añadir numeros negativos");
        }

        transaccion.Total = usuario.SaldoActual;
        usuario.SaldoActual += transaccion.Cantidad;

        _context.Transacciones.Add(transaccion);
        SaveChanges();
    }

    public void RestarCantidadTransaccion(Transaccion transaccion)
    {

        var usuario = _context.Usuarios.Find(transaccion.IdUsuario);
        if (usuario == null)
        {
            throw new KeyNotFoundException("No se encontró el usuario asociado con la transacción.");
        }

        if (transaccion.Cantidad <= 0)
        {
            throw new Exception("No se permiten numeros negativos");
        }

        if ((usuario.SaldoActual - transaccion.Cantidad) < 0)
        {
            throw new Exception("Ha superado el saldo de su cuenta");
        }

        transaccion.Total = usuario.SaldoActual;
        transaccion.Cantidad = -transaccion.Cantidad;

        usuario.SaldoActual += transaccion.Cantidad;


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
