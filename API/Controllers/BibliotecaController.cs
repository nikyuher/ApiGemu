using Microsoft.AspNetCore.Mvc;
using Gemu.Data;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BibliotecaController : ControllerBase
{
    private readonly ILogger<BibliotecaController> _logger;
    private readonly IBibliotecaService _bibliotecaService;

    public BibliotecaController(ILogger<BibliotecaController> logger, IBibliotecaService bibliotecaService)
    {
        _logger = logger;
        _bibliotecaService = bibliotecaService;
    }
}
