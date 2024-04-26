using Gemu.Data;

namespace Gemu.Business;
public class AnuncioService : IAnuncioService
{
    private readonly IAnuncioRepository _anuncioRepository;

    public AnuncioService(IAnuncioRepository repository)
    {
        _anuncioRepository = repository;
    }
}
