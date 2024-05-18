using Gemu.Models;

namespace Gemu.Data;
public interface ICarritoRepository
{
    //Read
    public List<Carrito> GetAllCarritos();
    public Carrito GetIdCarrito(int idCarrito);
    public CarritoListaDTO GetCarritoUsuario(int idUsuario);
    //Create
    void CreateCarritoUsuario(CarritoDTO carrito);
    void AñadirProductoCarrito(int idCarrito, int idProducto);
    void AñadirJuegoCarrito(int idBiblioteca, List<int> juegoDTO);
    //Update
    void UpdateCarrito(Carrito carrito);
    //Delete
    void DeleteCarrito(int idCarrito);
    void EliminarProductoCarrito(int idBiblioteca, int idProducto);
    void EliminarJuegoCarrito(int idBiblioteca, int idJuego);
}   