using Gemu.Data;

namespace Gemu.Business;
public class JuegoService : IJuegoService
{
    private readonly IJuegoRepository _juegoRepository;

    public JuegoService(IJuegoRepository repository)
    {
        _juegoRepository = repository;
    }
}
