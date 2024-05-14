using Gemu.Models;

namespace Gemu.Data;
public interface IAnuncioRepository
{
    //Read
    public List<Anuncio> GetAllAnuncios();
    public Anuncio GetIdAnuncio(int idAnuncio);
    public List<AnuncioDTO> GetAnunciosUsuario(int idUsuario);
    //Create
    void CreateAnuncio(AnuncioAddDTO anuncio);
    //Update
    void UpdateAnuncio(Anuncio anuncio);
    //Delete
    void DeleteAnuncio(int idAnuncio);
}   