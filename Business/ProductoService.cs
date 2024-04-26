using Gemu.Data;

namespace Gemu.Business;
public class ProductoService : IProductoService
{
    private readonly IProductoRepository _productoRepository;

    public ProductoService(IProductoRepository repository)
    {
        _productoRepository = repository;
    }
}
