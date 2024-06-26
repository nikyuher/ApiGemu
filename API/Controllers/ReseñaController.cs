using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Gemu.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ReseñaController : ControllerBase
{
    private readonly ILogger<ReseñaController> _logger;
    private readonly IReseñaService _reseñaService;
    private readonly IAuthService _authService;

    public ReseñaController(ILogger<ReseñaController> logger, IReseñaService reseñaService, IAuthService authService)
    {
        _logger = logger;
        _reseñaService = reseñaService;
        _authService = authService;
    }


    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public ActionResult<List<Reseña>> GetAllReseñas()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todos las reseñas.");
            return _reseñaService.GetAllReseñas();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos las reseñas: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

  [Authorize(Roles = "Admin")]
    [HttpGet("pendientes")]
    public ActionResult<List<Reseña>> GetAllReseñasPendientes()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todos las reseñas pendientes.");
            return _reseñaService.GetAllReseñasPendientes();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos las reseñas pendientes: {ex.Message}");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public ActionResult<Reseña> GetReseñaId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener la reseña con ID: {id}.");

            var reseña = _reseñaService.GetIdReseña(id);

            if (reseña == null)
            {
                _logger.LogWarning($"No se encontró ningúna reseña con ID: {id}.");
                return NotFound();
            }

            return reseña;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener la reseña con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPost("producto")]
    public IActionResult CreateReseñaProducto(int idProducto, [FromBody] ReseñaAddProducto reseña)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de la reseña.");

            if (idProducto != reseña.IdProducto)
            {
                _logger.LogError("El ID del rol en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, reseña.IdUsuario))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {reseña.IdUsuario}.");
                return Forbid();
            }

            _reseñaService.CreateReseñaProducto(reseña);
            return Ok(reseña);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear la reseña: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("juego")]
    public IActionResult CreateReseñaJuego(int idJuego, [FromBody] ReseñaAddJuego reseña)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de la reseña.");

            if (idJuego != reseña.IdJuego)
            {
                _logger.LogError("El ID del rol en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, reseña.IdUsuario))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {reseña.IdUsuario}.");
                return Forbid();
            }

            _reseñaService.CreateReseñaJuego(reseña);
            return Ok(reseña);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear la reseña: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("gestor-solicitud")]
    public IActionResult UpdateReseña([FromBody] AprobarReseñaDTO reseña)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización de la reseña con ID: {reseña.IdReseña}.");

            var existingReseña = _reseñaService.GetIdReseña(reseña.IdReseña);

            if (existingReseña is null)
            {
                _logger.LogWarning($"No se encontró ningún reseña con ID: {reseña.IdReseña}.");
                return NotFound();
            }

            _reseñaService.UpdateReseña(reseña);

            return Ok(reseña);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar la reseña con ID {reseña.IdReseña}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete("{id}/usuario")]
    public IActionResult DeleteReseña(int id, [FromBody] int idUsuario)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar la reseña con ID: {id}.");

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, idUsuario))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar la reseña del usuario con ID: {idUsuario}.");
                return Forbid();
            }

            var reseña = _reseñaService.GetIdReseña(id);

            if (reseña is null)
            {
                _logger.LogWarning($"No se encontró ningúna reseña con ID: {id}.");
                return NotFound();
            }

            _reseñaService.DeleteReseña(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar la reseña con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }
}
