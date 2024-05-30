using Gemu.Models;

namespace Gemu.Data;
public interface IJuegoRepository
{
    //Read
    public List<Juego> GetAllJuegos();
    public Task<IEnumerable<JuegoSearchDTO>> JuegoSearch(string Titulo);
    public List<Juego> GetJuegosPaginados(int pageNumber, int pageSize);
    public List<Juego> GetJuegosPaginadosOfertas(int pageNumber, int pageSize);
    public List<Juego> GetJuegosPaginadosBaratos(int pageNumber, int pageSize, int precioBarato);
    public List<Juego> GetJuegosPaginadosGratis(int pageNumber, int pageSize);
    public List<Juego> GetJuegosPaginadosCategoria(int pageNumber, int pageSize, List<int> categoriaIds);
    public JuegoDTO GetIdJuego(int idJuego);
    public JuegoCategoriasDTO GetCategoriasJuego(int idJuego);
    public JuegoReseñaDTO GetReseñasJuego(int idJuego);
    //Create
    public Juego  CreateJuego(JuegoAddDTO juego);
    void AsignarCategoriasJuego(int idJuego, List<int> ListaIdsCateogira);
    //Update
    void UpdateJuego(JuegoAddDTO juego);
    //Delte
    void DeleteJuego(int idJuego);
}