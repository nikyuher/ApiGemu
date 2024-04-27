using Gemu.Models;

namespace Gemu.Data;
public interface ICarritoRepository
{
    public List<Carrito> GetAllCarritos();
    public Carrito GetIdCarrito(int idCarrito);
    void CreateCarrito(Carrito carrito);
    void UpdateCarrito(Carrito carrito);
    void DeleteCarrito(int idCarrito);
}   