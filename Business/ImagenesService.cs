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

    public List<Imagen> GetAllImagenes()
    {
        return _imagenRepository.GetAllImagenes();
    }
    public Imagen GetIdImagen(int idImagen)
    {
        return _imagenRepository.GetIdImagen(idImagen);
    }
    public void CreateImagen(Imagen imagen)
    {
        _imagenRepository.CreateImagen(imagen);
    }
    public void UpdateImagen(Imagen imagen)
    {
        _imagenRepository.UpdateImagen(imagen);
    }
    public void DeleteImagen(int idImagen)
    {
        _imagenRepository.DeleteImagen(idImagen);
    }
}
