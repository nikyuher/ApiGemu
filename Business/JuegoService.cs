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
    public void CreateJuego(JuegoAddDTO juego)
    {
        _juegoRepository.CreateJuego(juego);
    }
    public void AsignarCategoriasJuego(int idJuego, List<int> ListaIdsCateogira)
    {
        _juegoRepository.AsignarCategoriasJuego(idJuego, ListaIdsCateogira);
    }
    public void AsignarReseñaJuego(int idJuego, List<int> ListaIdsReseñas)
    {
        _juegoRepository.AsignarReseñaJuego(idJuego, ListaIdsReseñas);
    }

    //Update
    public void UpdateJuego(Juego juego)
    {
        _juegoRepository.UpdateJuego(juego);
    }
    public void UpdateImgsJuego(int idJuego, List<Imagen> ListaImgs)
    {
        _juegoRepository.UpdateImgsJuego(idJuego, ListaImgs);
    }
    public void UpdateCategoriasJuego(int idJuego, List<Categoria> ListaCategoria)
    {
        _juegoRepository.UpdateCategoriasJuego(idJuego, ListaCategoria);
    }

    //Delete
    public void DeleteJuego(int idJuego)
    {
        _juegoRepository.DeleteJuego(idJuego);
    }
    public void EliminarCategoriasJuego(int idJuego, List<int> ListaIdsCateogira)
    {
        _juegoRepository.EliminarCategoriasJuego(idJuego, ListaIdsCateogira);
    }
    public void EliminarImgsJuego(int idJuego, List<int> ListaIdsReseñas)
    {
        _juegoRepository.EliminarImgsJuego(idJuego, ListaIdsReseñas);
    }
}
