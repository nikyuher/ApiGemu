using Gemu.Models;

namespace Gemu.Data;
public interface IJuegoRepository
{
    public List<Juego> GetAllJuegos();
    public Juego GetIdJuego(int idJuego);
    void CreateJuego(Juego juego);
    void UpdateJuego(Juego juego);
    void DeleteJuego(int idJuego);
}   