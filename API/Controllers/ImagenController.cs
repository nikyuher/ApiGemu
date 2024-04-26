using Microsoft.AspNetCore.Mvc;
using Gemu.Data;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagenController : ControllerBase
{
    private readonly ILogger<ImagenController> _logger;
    private readonly IImagenService _imagenService;

    public ImagenController(ILogger<ImagenController> logger, IImagenService imagenService)
    {
        _logger = logger;
        _imagenService = imagenService;
    }
}
