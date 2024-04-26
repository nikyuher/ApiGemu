namespace Gemu.Data;
public class ReseñaRepository : IReseñaRepository
{
    private readonly GemuContext _context;

    public ReseñaRepository(GemuContext context)
    {
        _context = context;
    }
}
