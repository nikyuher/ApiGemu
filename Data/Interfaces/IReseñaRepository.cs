using Gemu.Models;

namespace Gemu.Data;
public interface IReseñaRepository
{
    //Read
    public List<Reseña> GetAllReseñas();
    public List<Reseña> GetAllReseñasPendientes();
    public Reseña GetIdReseña(int idReseña);
    //Create
    void CreateReseñaProducto(ReseñaAddProducto reseña);
    void CreateReseñaJuego(ReseñaAddJuego reseña);
    //Update
    void UpdateReseña(AprobarReseñaDTO reseña);
    //Delete
    void DeleteReseña(int idReseña);
}   