using Gemu.Models;

namespace Gemu.Data;
public interface ITransaccionRepository
{
    //Read
    public List<TransaccionDTO> GetAllTransacciones();
    public List<Transaccion> GetTransaccionesUsuario (int idUsuario);
    public Transaccion GetIdTransaccion(int idTransaccion);
    //Create
    void AñadirCantidadTransaccion(Transaccion transaccion);
    void RestarCantidadTransaccion(Transaccion transaccion);
    //Update
    void UpdateTransaccion(Transaccion transaccion);
    //Delete
    void DeleteTransaccion(int idUsuario);
}   