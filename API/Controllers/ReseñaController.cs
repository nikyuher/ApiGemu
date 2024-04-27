using Microsoft.AspNetCore.Mvc;
using Gemu.Data;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ReseñaController : ControllerBase
{
    private readonly ILogger<ReseñaController> _logger;
    private readonly IReseñaService _reseñaService;

    public ReseñaController(ILogger<ReseñaController> logger, IReseñaService reseñaService)
    {
        _logger = logger;
        _reseñaService = reseñaService;
    }
    
}
