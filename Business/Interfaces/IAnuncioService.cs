using Gemu.Models;

namespace Gemu.Data;
public interface IAnuncioService
{
    //Read
    public List<Anuncio> GetAllAnuncios();
    public Anuncio GetIdAnuncio(int idAnuncio);
    public List<AnuncioDTO> GetAnunciosUsuario(int idUsuario);
    //Create
    void CreateAnuncio(Anuncio anuncio);
    //Update
    void UpdateAnuncio(Anuncio anuncio);
    //Delete
    void DeleteAnuncio(int idAnuncio);
}   