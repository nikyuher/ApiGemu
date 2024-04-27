using Gemu.Data;
using Gemu.Models;

namespace Gemu.Business;
public class CarritoService : ICarritoService
{
    private readonly ICarritoRepository _carritoRepository;

    public CarritoService(ICarritoRepository repository)
    {
        _carritoRepository = repository;
    }
    public List<Carrito> GetAllCarritos()
    {
        return _carritoRepository.GetAllCarritos();
    }
    public Carrito GetIdCarrito(int idCarrito)
    {
        return _carritoRepository.GetIdCarrito(idCarrito);
    }
    public void CreateCarrito(Carrito carrito)
    {
        _carritoRepository.CreateCarrito(carrito);
    }
    public void UpdateCarrito(Carrito carrito)
    {
        _carritoRepository.UpdateCarrito(carrito);
    }
    public void DeleteCarrito(int idCarrito)
    {
        _carritoRepository.DeleteCarrito(idCarrito);
    }
}
