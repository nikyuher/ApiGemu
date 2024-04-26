namespace Gemu.Data;
public class CarritoRepository : ICarritoRepository
{
    private readonly GemuContext _context;

    public CarritoRepository(GemuContext context)
    {
        _context = context;
    }
}
