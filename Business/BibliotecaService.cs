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

    //Read
    public List<BibliotecaListaDTO> GetAllBibliotecas()
    {
        return _bibliotecaRepository.GetAllBibliotecas();
    }
    public BibliotecaListaDTO GetIdBiblioteca(int idBiblioteca)
    {
        return _bibliotecaRepository.GetIdBiblioteca(idBiblioteca);
    }
    public BibliotecaListaDTO GetBibliotecaUsuario(int idUsuario)
    {
        return _bibliotecaRepository.GetBibliotecaUsuario(idUsuario);
    }
    //Create
    public void CreateBibliotecaUsuario(BibliotecaDTO biblioteca)
    {
        _bibliotecaRepository.CreateBibliotecaUsuario(biblioteca);
    }
    public void AñadirProductoBiblioteca(int idBiblioteca, List<ProductoBibliotecaDTO> productoBibliotecaDTO)
    {
        _bibliotecaRepository.AñadirProductoBiblioteca(idBiblioteca, productoBibliotecaDTO);
    }
    public void AñadirJuegoBiblioteca(int idBiblioteca, List<JuegoBiliotecaDTO> juegoDTO)
    {
        _bibliotecaRepository.AñadirJuegoBiblioteca(idBiblioteca, juegoDTO);
    }
    //Update
    public void UpdateBiblioteca(Biblioteca biblioteca)
    {
        _bibliotecaRepository.UpdateBiblioteca(biblioteca);
    }
    //Delete
    public void DeleteBiblioteca(int idBiblioteca)
    {
        _bibliotecaRepository.DeleteBiblioteca(idBiblioteca);
    }

    public void EliminarProductoBiblioteca(int idBiblioteca, int idProducto)
    {
        _bibliotecaRepository.EliminarProductoBiblioteca(idBiblioteca, idProducto);
    }

    public void EliminarJuegoBiblioteca(int idBiblioteca, int idJuego)
    {
        _bibliotecaRepository.EliminarJuegoBiblioteca(idBiblioteca, idJuego);
    }
}
