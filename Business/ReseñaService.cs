using Gemu.Data;
using Gemu.Models;

namespace Gemu.Business;
public class ReseñaService : IReseñaService
{
    private readonly IReseñaRepository _reseñaRepository;

    public ReseñaService(IReseñaRepository repository)
    {
        _reseñaRepository = repository;
    }

    public List<Reseña> GetAllReseñas()
    {
        return _reseñaRepository.GetAllReseñas();
    }
    public Reseña GetIdReseña(int idReseña)
    {
        return _reseñaRepository.GetIdReseña(idReseña);
    }
    //Create
    public void CreateReseñaProducto(ReseñaAddProducto reseña)
    {
        _reseñaRepository.CreateReseñaProducto(reseña);
    }
    public void CreateReseñaJuego(ReseñaAddJuego reseña)
    {
        _reseñaRepository.CreateReseñaJuego(reseña);
    }
    //Update
    public void UpdateReseña(AprobarReseñaDTO reseña)
    {
        _reseñaRepository.UpdateReseña(reseña);
    }
    //Delete
    public void DeleteReseña(int idReseña)
    {
        _reseñaRepository.DeleteReseña(idReseña);
    }
}
