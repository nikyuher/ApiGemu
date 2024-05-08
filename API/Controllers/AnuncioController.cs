using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Gemu.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AnuncioController : ControllerBase
{
    private readonly ILogger<AnuncioController> _logger;
    private readonly IAnuncioService _anuncioService;
    private readonly IAuthService _authService;

    public AnuncioController(ILogger<AnuncioController> logger, IAnuncioService anuncioService, IAuthService authService)
    {
        _logger = logger;
        _anuncioService = anuncioService;
        _authService = authService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public ActionResult<List<Anuncio>> GetAllAnuncios()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todos los anuncios.");
            return _anuncioService.GetAllAnuncios();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los anuncios: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [Authorize(Roles = "Usuario")]
    [HttpGet("usuario")]
    public ActionResult<List<AnuncioDTO>> GetAnunciosUsuario(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener todos los anuncios del usuario {id}.");

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, id))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {id}.");
                return Forbid();
            }

            return _anuncioService.GetAnunciosUsuario(id);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los anuncios del usuario {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public ActionResult<Anuncio> GetAnuncioId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener el anuncio con ID: {id}.");

            var anuncio = _anuncioService.GetIdAnuncio(id);

            if (anuncio == null)
            {
                _logger.LogWarning($"No se encontró ningún anuncio con ID: {id}.");
                return NotFound();
            }

            return anuncio;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener el anuncio con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [Authorize(Roles = "Usuario")]
    [HttpPost("crear")]
    public IActionResult CreateAnuncio([FromBody] Anuncio anuncio)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de anuncio.");

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, anuncio.IdUsuario))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {anuncio.IdUsuario}.");
                return Forbid();
            }

            _anuncioService.CreateAnuncio(anuncio);
            return Ok(anuncio);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear anuncio: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Usuario")]
    [HttpPut("{id}")]
    public IActionResult UpdateAnuncio(int id, [FromBody] Anuncio anuncio)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización del anuncio con ID: {id}.");

            if (id != anuncio.IdAnuncio)
            {
                _logger.LogError("El ID del anuncio en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, anuncio.IdUsuario))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {anuncio.IdUsuario}.");
                return Forbid();
            }

            var existingAnuncio = _anuncioService.GetIdAnuncio(id);

            if (existingAnuncio is null)
            {
                _logger.LogWarning($"No se encontró ningún anuncio con ID: {id}.");
                return NotFound();
            }

            _anuncioService.UpdateAnuncio(anuncio);

            return Ok(anuncio);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar anuncio con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [Authorize(Roles = "Usuario")]
    [HttpDelete("{id}")]
    public IActionResult DeleteAnuncio(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar el anuncio con ID: {id}.");

            var anuncio = _anuncioService.GetIdAnuncio(id);

            if (anuncio is null)
            {
                _logger.LogWarning($"No se encontró ningún anuncio con ID: {id}.");
                return NotFound();
            }

            _anuncioService.DeleteAnuncio(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar anuncio con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }
}
