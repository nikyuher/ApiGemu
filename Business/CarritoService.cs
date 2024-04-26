using Gemu.Data;

namespace Gemu.Business;
public class CarritoService : ICarritoService
{
    private readonly ICarritoRepository _carritoRepository;

    public CarritoService(ICarritoRepository repository)
    {
        _carritoRepository = repository;
    }
}
