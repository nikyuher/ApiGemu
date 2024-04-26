namespace Gemu.Data;
public class AnuncioRepository : IAnuncioRepository
{
    private readonly GemuContext _context;

    public AnuncioRepository(GemuContext context)
    {
        _context = context;
    }
}
