using Gemu.Data;
using Gemu.Models;

namespace Gemu.Business;
public class ImagenService : IImagenService
{
    private readonly IImagenRepository _imagenRepository;

    public ImagenService(IImagenRepository repository)
    {
        _imagenRepository = repository;
    }


    //Read
    public List<Imagen> GetAllImagenes()
    {
        return _imagenRepository.GetAllImagenes();
    }
    public Imagen GetIdImagen(int idImagen)
    {
        return _imagenRepository.GetIdImagen(idImagen);
    }
    public List<ImagenJuegoDTO> GetImagenesJuego(int id)
    {
        return _imagenRepository.GetImagenesJuego(id);
    }
    public List<ImagenProductoDTO> GetImagenesProducto(int id)
    {
        return _imagenRepository.GetImagenesProducto(id);
    }
    //Create
    public void CreateImagen(Imagen imagen)
    {
        _imagenRepository.CreateImagen(imagen);
    }
    public void CreateImagenJuego(List<ImagenJuegoDTO> Listaimagen)
    {
        _imagenRepository.CreateImagenJuego(Listaimagen);
    }
    public void CreateImagenProducto(List<ImagenProductoDTO> Listaimagen)
    {
        _imagenRepository.CreateImagenProducto(Listaimagen);
    }

    //Update
    public void UpdateImagenJuego(List<ImagenJuegoDTO> ListaImagen)
    {
        _imagenRepository.UpdateImagenJuego(ListaImagen);
    }
    public void UpdateImagenProducto(List<ImagenProductoDTO> ListaImagen)
    {
        _imagenRepository.UpdateImagenProducto(ListaImagen);
    }

    //Delete
    public void DeleteImagen(List<int> ListaIds)
    {
        _imagenRepository.DeleteImagen(ListaIds);
    }
}
