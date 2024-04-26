namespace Gemu.Data;
public class ImagenRepository : IImagenRepository
{
    private readonly GemuContext _context;

    public ImagenRepository(GemuContext context)
    {
        _context = context;
    }
}
