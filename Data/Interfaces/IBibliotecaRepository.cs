using Gemu.Models;

namespace Gemu.Data;
public interface IBibliotecaRepository
{
    //Read
    public List<Biblioteca> GetAllBibliotecas();
    public Biblioteca GetIdBiblioteca(int idBiblioteca);
    public BibliotecaListaDTO GetBibliotecaUsuario(int idUsuario);
    //Create
    void CreateBibliotecaUsuario(BibliotecaDTO biblioteca);
    //Update
    void UpdateBiblioteca(Biblioteca biblioteca);
    //Delete
    void DeleteBiblioteca(int idBiblioteca);
}   