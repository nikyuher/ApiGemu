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
    public void CreateReseña(ReseñaAddDTO reseña)
    {
        _reseñaRepository.CreateReseña(reseña);
    }
    public void UpdateReseña(AprobarReseñaDTO reseña)
    {
        _reseñaRepository.UpdateReseña(reseña);
    }
    public void DeleteReseña(int idReseña)
    {
        _reseñaRepository.DeleteReseña(idReseña);
    }
}
