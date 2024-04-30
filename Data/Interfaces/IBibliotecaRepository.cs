using Gemu.Models;

namespace Gemu.Data;
public interface IBibliotecaRepository
{
    //Read
    public List<BibliotecaListaDTO> GetAllBibliotecas();
    public BibliotecaListaDTO GetIdBiblioteca(int idBiblioteca);
    public BibliotecaListaDTO GetBibliotecaUsuario(int idUsuario);
    //Create
    void CreateBibliotecaUsuario(BibliotecaDTO biblioteca);
    void AñadirProductoBiblioteca(int idBiblioteca, List<ProductoBibliotecaDTO> productoBibliotecaDTO);
    void AñadirJuegoBiblioteca(int idBiblioteca, List<JuegoBiliotecaDTO> juegoDTO);
    //Update
    void UpdateBiblioteca(Biblioteca biblioteca);
    //Delete
    void DeleteBiblioteca(int idBiblioteca);
    void EliminarProductoBiblioteca(int idBiblioteca, int idProducto);
    void EliminarJuegoBiblioteca(int idBiblioteca, int idJuego);
}   