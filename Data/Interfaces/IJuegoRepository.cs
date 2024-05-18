using Gemu.Models;

namespace Gemu.Data;
public interface IJuegoRepository
{
    //Read
    public List<Juego> GetAllJuegos();
    public JuegoDTO GetIdJuego(int idJuego);
    public JuegoCategoriasDTO GetCategoriasJuego(int idJuego);
    public JuegoReseñaDTO GetReseñasJuego(int idJuego);
    //Create
    void CreateJuego(JuegoAddDTO juego);
    void AsignarCategoriasJuego(int idJuego, List<int> ListaIdsCateogira);
    //Update
    void UpdateJuego(Juego juego);
    //Delte
    void DeleteJuego(int idJuego);
}