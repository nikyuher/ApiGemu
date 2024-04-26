using Microsoft.AspNetCore.Mvc;
using Gemu.Data;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarritoController : ControllerBase
{
    private readonly ILogger<CarritoController> _logger;
    private readonly ICarritoService _carritoService;

    public CarritoController(ILogger<CarritoController> logger, ICarritoService carritoService)
    {
        _logger = logger;
        _carritoService = carritoService;
    }
}
