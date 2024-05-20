using Gemu.Models;

namespace Gemu.Data;
public interface IJuegoService
{
    //Read
    public List<Juego> GetAllJuegos();
    public List<Juego> GetJuegosPaginados(int pageNumber, int pageSize);
    public JuegoDTO GetIdJuego(int idJuego);
    public JuegoCategoriasDTO GetCategoriasJuego(int idJuego);
    public JuegoReseñaDTO GetReseñasJuego(int idJuego);
    //Create
    void CreateJuego(JuegoAddDTO juego);
    void AsignarCategoriasJuego(int idJuego, List<int> ListaIdsCateogira);
    //Update
    void UpdateJuego(Juego juego);
    //Delete
    void DeleteJuego(int idJuego);
}