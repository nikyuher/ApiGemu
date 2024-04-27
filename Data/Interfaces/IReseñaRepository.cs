using Gemu.Models;

namespace Gemu.Data;
public interface IReseñaRepository
{
    public List<Reseña> GetAllReseñas();
    public Reseña GetIdReseña(int idReseña);
    void CreateReseña(Reseña reseña);
    void UpdateReseña(Reseña reseña);
    void DeleteReseña(int idReseña);
}   