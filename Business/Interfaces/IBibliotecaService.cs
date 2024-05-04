using Gemu.Models;

namespace Gemu.Data;
public interface IBibliotecaService
{
    //Read
    public List<BibliotecaListaDTO> GetAllBibliotecas();
    public BibliotecaListaDTO GetIdBiblioteca(int idBiblioteca);
    public BibliotecaListaDTO GetBibliotecaUsuario(int idUsuario);
    //Create
    void CreateBibliotecaUsuario(BibliotecaDTO biblioteca);
    void AñadirProductoBiblioteca(int idBiblioteca, List<int> productoBibliotecaDTO);
    void AñadirJuegoBiblioteca(int idBiblioteca, List<int> juegoDTO);
    //Update
    void UpdateBiblioteca(Biblioteca biblioteca);
    //Delete
    void DeleteBiblioteca(int idBiblioteca);
    void EliminarProductoBiblioteca(int idBiblioteca, int idProducto);
    void EliminarJuegoBiblioteca(int idBiblioteca, int idJuego);
}   