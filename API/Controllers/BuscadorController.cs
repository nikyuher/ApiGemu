using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Gemu.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class BuscadorController : ControllerBase
{
    private readonly ILogger<ImagenController> _logger;
    private readonly IJuegoService _juegoService;
    private readonly IProductoService _productoService;
    private readonly IAuthService _authService;

    public BuscadorController(ILogger<ImagenController> logger, IJuegoService juegoService, IAuthService authService, IProductoService productoService)
    {
        _logger = logger;
        _juegoService = juegoService;
        _productoService = productoService;
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpGet()]
    public async Task<IActionResult> Search(string nombre)
    {

        try
        {
            _logger.LogInformation("Se ha solicitado obtener juegos y productos.");
            var juegos = await _juegoService.JuegoSearch(nombre);
            var productos = await _productoService.ProductoSearch(nombre);

            var resultados = new
            {
                Juegos = juegos,
                Productos = productos
            };

            return Ok(resultados);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos juegos y productos: {ex.Message}");
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
