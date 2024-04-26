namespace Gemu.Data;
public class BibliotecaRepository : IBibliotecaRepository
{
    private readonly GemuContext _context;

    public BibliotecaRepository(GemuContext context)
    {
        _context = context;
    }
}
