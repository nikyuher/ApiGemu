using Gemu.Models;

namespace Gemu.Data;
public interface IReseñaService
{
    //Read
    public List<Reseña> GetAllReseñas();
    public Reseña GetIdReseña(int idReseña);
    //Create
    void CreateReseñaProducto(ReseñaAddProducto reseña);
    void CreateReseñaJuego(ReseñaAddJuego reseña);
    //Update
    void UpdateReseña(AprobarReseñaDTO reseña);
    //Delete
    void DeleteReseña(int idReseña);
}