namespace Gemu.Data;
public class ProductoRepository : IProductoRepository
{
    private readonly GemuContext _context;

    public ProductoRepository(GemuContext context)
    {
        _context = context;
    }
}
