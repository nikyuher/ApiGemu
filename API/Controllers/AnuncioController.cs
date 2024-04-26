using Microsoft.AspNetCore.Mvc;
using Gemu.Data;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AnuncioController : ControllerBase
{
    private readonly ILogger<AnuncioController> _logger;
    private readonly IAnuncioService _anuncioService;

    public AnuncioController(ILogger<AnuncioController> logger, IAnuncioService anuncioService)
    {
        _logger = logger;
        _anuncioService = anuncioService;
    }
}
