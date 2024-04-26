using Microsoft.AspNetCore.Mvc;
using Gemu.Data;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class JuegoController : ControllerBase
{
    private readonly ILogger<JuegoController> _logger;
    private readonly IJuegoService _juegoService;

    public JuegoController(ILogger<JuegoController> logger, IJuegoService juegoService)
    {
        _logger = logger;
        _juegoService = juegoService;
    }
}
