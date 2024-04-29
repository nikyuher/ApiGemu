using Gemu.Data;
using Gemu.Models;

namespace Gemu.Business;
public class TransaccionService : ITransaccionService
{
    private readonly ITransaccionRepository _transaccionRepository;

    public TransaccionService(ITransaccionRepository repository)
    {
        _transaccionRepository = repository;
    }

    public List<TransaccionDTO> GetAllTransacciones()
    {
        return _transaccionRepository.GetAllTransacciones();
    }
    public List<Transaccion> GetTransaccionesUsuario (int idUsuario){
        return _transaccionRepository.GetTransaccionesUsuario(idUsuario);
    }
    public Transaccion GetIdTransaccion(int idTransaccion)
    {
        return _transaccionRepository.GetIdTransaccion(idTransaccion);
    }
    public void AñadirCantidadTransaccion(Transaccion transaccion)
    {
        _transaccionRepository.AñadirCantidadTransaccion(transaccion);
    }
    public void RestarCantidadTransaccion(Transaccion transaccion)
    {
        _transaccionRepository.RestarCantidadTransaccion(transaccion);
    }
    public void UpdateTransaccion(Transaccion transaccion)
    {
        _transaccionRepository.UpdateTransaccion(transaccion);
    }
    public void DeleteTransaccion(int idTransaccion)
    {
        _transaccionRepository.DeleteTransaccion(idTransaccion);
    }
    
}
