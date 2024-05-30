using Gemu.Data;
using Gemu.Models;

namespace Gemu.Business;
public class JuegoService : IJuegoService
{
    private readonly IJuegoRepository _juegoRepository;

    public JuegoService(IJuegoRepository repository)
    {
        _juegoRepository = repository;
    }


    //Read
    public List<Juego> GetAllJuegos()
    {
        return _juegoRepository.GetAllJuegos();
    }

    public async Task<IEnumerable<JuegoSearchDTO>> JuegoSearch(string Titulo)
    {
        return await _juegoRepository.JuegoSearch(Titulo);
    }

    public List<Juego> GetJuegosPaginados(int pageNumber, int pageSize)
    {
        return _juegoRepository.GetJuegosPaginados(pageNumber, pageSize);
    }
    public List<Juego> GetJuegosPaginadosOfertas(int pageNumber, int pageSize)
    {
        return _juegoRepository.GetJuegosPaginadosOfertas(pageNumber, pageSize);
    }
    public List<Juego> GetJuegosPaginadosBaratos(int pageNumber, int pageSize, int precioBarato)
    {
        return _juegoRepository.GetJuegosPaginadosBaratos(pageNumber, pageSize, precioBarato);
    }
    public List<Juego> GetJuegosPaginadosGratis(int pageNumber, int pageSize)
    {
        return _juegoRepository.GetJuegosPaginadosGratis(pageNumber, pageSize);
    }

    public List<Juego> GetJuegosPaginadosCategoria(int pageNumber, int pageSize, List<int> categoriaIds)
    {
        return _juegoRepository.GetJuegosPaginadosCategoria(pageNumber, pageSize, categoriaIds);
    }
    public JuegoDTO GetIdJuego(int idJuego)
    {
        return _juegoRepository.GetIdJuego(idJuego);
    }
    public JuegoCategoriasDTO GetCategoriasJuego(int idJuego)
    {
        return _juegoRepository.GetCategoriasJuego(idJuego);
    }
    public JuegoReseñaDTO GetReseñasJuego(int idJuego)
    {
        return _juegoRepository.GetReseñasJuego(idJuego);
    }

    //Create
    public Juego CreateJuego(JuegoAddDTO juego)
    {
        return _juegoRepository.CreateJuego(juego);
    }
    public void AsignarCategoriasJuego(int idJuego, List<int> ListaIdsCateogira)
    {
        _juegoRepository.AsignarCategoriasJuego(idJuego, ListaIdsCateogira);
    }

    //Update
    public void UpdateJuego(JuegoAddDTO juego)
    {
        _juegoRepository.UpdateJuego(juego);
    }

    //Delete
    public void DeleteJuego(int idJuego)
    {
        _juegoRepository.DeleteJuego(idJuego);
    }
}
