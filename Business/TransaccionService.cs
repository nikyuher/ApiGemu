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

    public List<Transaccion> GetAllTransacciones()
    {
        return _transaccionRepository.GetAllTransacciones();
    }
    public Transaccion GetIdTransaccion(int idTransaccion)
    {
        return _transaccionRepository.GetIdTransaccion(idTransaccion);
    }
    public void CreateTransaccion(Transaccion transaccion)
    {
        _transaccionRepository.CreateTransaccion(transaccion);
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
