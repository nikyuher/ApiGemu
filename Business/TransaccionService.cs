using Gemu.Data;

namespace Gemu.Business;
public class TransaccionService : ITransaccionService
{
    private readonly ITransaccionRepository _transaccionRepository;

    public TransaccionService(ITransaccionRepository repository)
    {
        _transaccionRepository = repository;
    }
}
