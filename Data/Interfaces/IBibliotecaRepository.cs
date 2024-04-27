using Gemu.Models;

namespace Gemu.Data;
public interface IBibliotecaRepository
{
    public List<Biblioteca> GetAllBibliotecas();
    public Biblioteca GetIdBiblioteca(int idBiblioteca);
    void CreateBiblioteca(Biblioteca biblioteca);
    void UpdateBiblioteca(Biblioteca biblioteca);
    void DeleteBiblioteca(int idBiblioteca);
}   