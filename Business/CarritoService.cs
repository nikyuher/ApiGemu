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

    //Read
    public List<Carrito> GetAllCarritos()
    {
        return _carritoRepository.GetAllCarritos();
    }
    public Carrito GetIdCarrito(int idCarrito)
    {
        return _carritoRepository.GetIdCarrito(idCarrito);
    }
    public CarritoListaDTO GetCarritoUsuario(int idUsuario)
    {
        return _carritoRepository.GetCarritoUsuario(idUsuario);
    }
    //Create
    public void CreateCarritoUsuario(CarritoDTO carrito)
    {
        _carritoRepository.CreateCarritoUsuario(carrito);
    }

    public void AñadirProductoCarrito(int idBiblioteca, int idProducto)
    {
        _carritoRepository.AñadirProductoCarrito(idBiblioteca, idProducto);
    }

    public void AñadirJuegoCarrito(int idBiblioteca, List<int> ListaIdsJuego)
    {
        _carritoRepository.AñadirJuegoCarrito(idBiblioteca, ListaIdsJuego);
    }

    //Update
    public void UpdateCarrito(Carrito carrito)
    {
        _carritoRepository.UpdateCarrito(carrito);
    }
    //Delete
    public void DeleteCarrito(int idCarrito)
    {
        _carritoRepository.DeleteCarrito(idCarrito);
    }

        public void EliminarProductoCarrito(int idBiblioteca, int idProducto)
    {
        _carritoRepository.EliminarProductoCarrito(idBiblioteca, idProducto);
    }

    public void EliminarJuegoCarrito(int idBiblioteca, int idJuego)
    {
        _carritoRepository.EliminarJuegoCarrito(idBiblioteca, idJuego);
    }
}
