namespace Gemu.Data;
public class TransaccionRepository : ITransaccionRepository
{
    private readonly GemuContext _context;

    public TransaccionRepository(GemuContext context)
    {
        _context = context;
    }
}
