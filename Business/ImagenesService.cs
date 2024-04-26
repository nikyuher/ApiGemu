using Gemu.Data;

namespace Gemu.Business;
public class ImagenService : IImagenService
{
    private readonly IImagenRepository _imagenRepository;

    public ImagenService(IImagenRepository repository)
    {
        _imagenRepository = repository;
    }
}
