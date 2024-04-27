using Gemu.Models;

namespace Gemu.Data;
public interface IAnuncioRepository
{
    public List<Anuncio> GetAllAnuncios();
    public Anuncio GetIdAnuncio(int idAnuncio);
    void CreateAnuncio(Anuncio anuncio);
    void UpdateAnuncio(Anuncio anuncio);
    void DeleteAnuncio(int idAnuncio);
}   