using Gemu.Data;

namespace Gemu.Business;
public class BibliotecaService : IBibliotecaService
{
    private readonly IBibliotecaRepository _bibliotecaRepository;

    public BibliotecaService(IBibliotecaRepository repository)
    {
        _bibliotecaRepository = repository;
    }
}
