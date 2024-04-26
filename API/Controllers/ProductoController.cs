using Microsoft.AspNetCore.Mvc;
using Gemu.Data;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly ILogger<ProductoController> _logger;
    private readonly IProductoService _productoService;

    public ProductoController(ILogger<ProductoController> logger, IProductoService productoService)
    {
        _logger = logger;
        _productoService = productoService;
    }
}
