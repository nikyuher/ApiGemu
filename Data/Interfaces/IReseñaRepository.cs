using Gemu.Models;

namespace Gemu.Data;
public interface IReseñaRepository
{
    public List<Reseña> GetAllReseñas();
    public Reseña GetIdReseña(int idReseña);
    void CreateReseña(ReseñaAddDTO reseña);
    void UpdateReseña(AprobarReseñaDTO reseña);
    void DeleteReseña(int idReseña);
}   