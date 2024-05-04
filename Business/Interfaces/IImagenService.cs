using Gemu.Models;

namespace Gemu.Data;
public interface IImagenService
{
    //Read
    public List<Imagen> GetAllImagenes();
    public Imagen GetIdImagen(int idImagen);
    public List<ImagenJuegoDTO> GetImagenesJuego(int id);
    public List<ImagenProductoDTO> GetImagenesProducto(int id);
    //Create
    void CreateImagen(Imagen imagen);
    void CreateImagenJuego(List<ImagenJuegoDTO> Listaimagen);
    void CreateImagenProducto(List<ImagenProductoDTO> Listaimagen);
    //Update
    void UpdateImagenJuego(List<ImagenJuegoDTO> Listaimagen);
    void UpdateImagenProducto(List<ImagenProductoDTO> Listaimagen);
    //Delete
    void DeleteImagen(List<int> ListaId);
}