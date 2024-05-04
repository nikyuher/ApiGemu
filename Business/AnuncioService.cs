using Gemu.Data;
using Gemu.Models;

namespace Gemu.Business;
public class AnuncioService : IAnuncioService
{
    private readonly IAnuncioRepository _anuncioRepository;

    public AnuncioService(IAnuncioRepository repository)
    {
        _anuncioRepository = repository;
    }

    public List<Anuncio> GetAllAnuncios()
    {
        return _anuncioRepository.GetAllAnuncios();
    }
    public List<AnuncioDTO> GetAnunciosUsuario(int idUsuario)
    {
        return _anuncioRepository.GetAnunciosUsuario(idUsuario);
    }
    public Anuncio GetIdAnuncio(int idAnuncio)
    {
        return _anuncioRepository.GetIdAnuncio(idAnuncio);
    }
    public void CreateAnuncio(Anuncio anuncio)
    {
        _anuncioRepository.CreateAnuncio(anuncio);
    }
    public void UpdateAnuncio(Anuncio anuncio)
    {
        _anuncioRepository.UpdateAnuncio(anuncio);
    }
    public void DeleteAnuncio(int idAnuncio)
    {
        _anuncioRepository.DeleteAnuncio(idAnuncio);
    }
}
