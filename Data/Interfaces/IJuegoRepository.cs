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
    void AsignarReseñaJuego(int idJuego, List<int> ListaIdsReseñas);
    //Update
    void UpdateJuego(Juego juego);
    void UpdateImgsJuego(int idJuego, List<Imagen> ListaImgs);
    void UpdateCategoriasJuego(int idJuego, List<Categoria> ListaCategoria);
    //Delte
    void DeleteJuego(int idJuego);
    void EliminarCategoriasJuego(int idJuego, List<int> ListaIdsCateogira);
    void EliminarImgsJuego(int idJuego, List<int> ListaIdsReseñas);
}