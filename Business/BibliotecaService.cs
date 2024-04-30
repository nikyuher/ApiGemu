using Gemu.Data;
using Gemu.Models;

namespace Gemu.Business;
public class BibliotecaService : IBibliotecaService
{
    private readonly IBibliotecaRepository _bibliotecaRepository;

    public BibliotecaService(IBibliotecaRepository repository)
    {
        _bibliotecaRepository = repository;
    }

    public List<Biblioteca> GetAllBibliotecas()
    {
        return _bibliotecaRepository.GetAllBibliotecas();
    }
    public Biblioteca GetIdBiblioteca(int idBiblioteca)
    {
        return _bibliotecaRepository.GetIdBiblioteca(idBiblioteca);
    }
    public BibliotecaListaDTO GetBibliotecaUsuario(int idUsuario)
    {
        return _bibliotecaRepository.GetBibliotecaUsuario(idUsuario);
    }
    public void CreateBibliotecaUsuario(BibliotecaDTO biblioteca)
    {
        _bibliotecaRepository.CreateBibliotecaUsuario(biblioteca);
    }
    public void UpdateBiblioteca(Biblioteca biblioteca)
    {
        _bibliotecaRepository.UpdateBiblioteca(biblioteca);
    }
    public void DeleteBiblioteca(int idBiblioteca)
    {
        _bibliotecaRepository.DeleteBiblioteca(idBiblioteca);
    }
}
