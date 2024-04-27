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

    public List<Juego> GetAllJuegos()
    {
        return _juegoRepository.GetAllJuegos();
    }
    public Juego GetIdJuego(int idJuego)
    {
        return _juegoRepository.GetIdJuego(idJuego);
    }
    public void CreateJuego(Juego juego)
    {
        _juegoRepository.CreateJuego(juego);
    }
    public void UpdateJuego(Juego juego)
    {
        _juegoRepository.UpdateJuego(juego);
    }
    public void DeleteJuego(int idJuego)
    {
        _juegoRepository.DeleteJuego(idJuego);
    }
}
