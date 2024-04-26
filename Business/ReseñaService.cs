using Gemu.Data;

namespace Gemu.Business;
public class ReseñaService : IReseñaService
{
    private readonly IReseñaRepository _reseñaRepository;

    public ReseñaService(IReseñaRepository repository)
    {
        _reseñaRepository = repository;
    }
}
