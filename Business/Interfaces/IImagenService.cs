using Gemu.Models;

namespace Gemu.Data;
public interface IImagenService
{
    public List<Imagen> GetAllImagenes();
    public Imagen GetIdImagen(int idImagen);
    void CreateImagen(Imagen imagen);
    void UpdateImagen(Imagen imagen);
    void DeleteImagen(int idImagen);
}   