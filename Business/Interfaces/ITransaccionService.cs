using Gemu.Models;

namespace Gemu.Data;
public interface ITransaccionService
{
    public List<Transaccion> GetAllTransacciones();
    public Transaccion GetIdTransaccion(int idTransaccion);
    void CreateTransaccion(Transaccion Transaccio);
    void UpdateTransaccion(Transaccion Transaccio);
    void DeleteTransaccion(int idTransaccio);
}   