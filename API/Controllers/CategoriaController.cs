using Microsoft.AspNetCore.Mvc;
using Gemu.Data;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ILogger<CategoriaController> _logger;
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService categoriaService)
    {
        _logger = logger;
        _categoriaService = categoriaService;
    }
}
