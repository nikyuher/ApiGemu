using Gemu.Models;

namespace Gemu.Data;
public interface ITransaccionRepository
{
    public List<Transaccion> GetAllTransacciones();
    public Transaccion GetIdTransaccion(int idTransaccion);
    void CreateTransaccion(Transaccion transaccion);
    void UpdateTransaccion(Transaccion transaccion);
    void DeleteTransaccion(int idUsuario);
}   