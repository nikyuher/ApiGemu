using Gemu.Models;

namespace Gemu.Data;
public interface ITransaccionService
{
    public List<TransaccionDTO> GetAllTransacciones();
    public List<Transaccion> GetTransaccionesUsuario (int idUsuario);
    public Transaccion GetIdTransaccion(int idTransaccion);
    void AñadirCantidadTransaccion(Transaccion transaccion);
    void RestarCantidadTransaccion(Transaccion transaccion);
    void UpdateTransaccion(Transaccion transaccion);
    void DeleteTransaccion(int idTransaccion);
}   