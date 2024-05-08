using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Gemu.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class TransaccionController : ControllerBase
{
    private readonly ILogger<TransaccionController> _logger;
    private readonly ITransaccionService _transaccionService;
    private readonly IAuthService _authService;

    public TransaccionController(ILogger<TransaccionController> logger, ITransaccionService transaccionService, IAuthService authService)
    {
        _logger = logger;
        _transaccionService = transaccionService;
        _authService = authService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet(Name = "GetAllTransacciones")]
    public ActionResult<List<TransaccionDTO>> GetAllTransacciones()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todas las transacciones.");
            return _transaccionService.GetAllTransacciones();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todas las transaccion: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }


    [HttpGet("usuario", Name = "GetTransaccionesUsuario")]
    public ActionResult<List<Transaccion>> GetTransaccionesUsuario(int idUsuario)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener todas las transacciones del usuario con el ID {idUsuario}.");

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, idUsuario))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {idUsuario}.");
                return Forbid();
            }

            return _transaccionService.GetTransaccionesUsuario(idUsuario);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todas las transaccion: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}", Name = "GetTransaccionId")]
    public ActionResult<Transaccion> GetTransaccionId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener la transaccion con ID: {id}.");

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, id))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {id}.");
                return Forbid();
            }

            var transaccion = _transaccionService.GetIdTransaccion(id);

            if (transaccion == null)
            {
                _logger.LogWarning($"No se encontró ningúna transaccion con el ID: {id}.");
                return NotFound();
            }

            return transaccion;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener la transaccion con el ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }


    [HttpPost("añadir-fondos", Name = "AñadirFondos")]
    public IActionResult AñadirCantidadTransaccion([FromBody] Transaccion transaccion)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitado añadir Saldo.");

            _transaccionService.AñadirCantidadTransaccion(transaccion);
            return Ok(transaccion);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear una transaccion: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("restar-fondos", Name = "RestarFondos")]
    public IActionResult RestarCantidadTransaccion([FromBody] Transaccion transaccion)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de restar Saldo.");

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, transaccion.IdUsuario))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {transaccion.IdUsuario}.");
                return Forbid();
            }

            _transaccionService.RestarCantidadTransaccion(transaccion);
            return Ok(transaccion);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear una transaccion: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut(Name = "PutTransaccion")]
    public IActionResult UpdateTransaccion(int id, [FromBody] Transaccion transaccion)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización de la transaccion con ID: {id}.");

            if (id != transaccion.IdTransaccion)
            {
                _logger.LogError("El ID de la transaccion en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, id))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {id}.");
                return Forbid();
            }

            var existingTransaccion = _transaccionService.GetIdTransaccion(id);

            if (existingTransaccion is null)
            {
                _logger.LogWarning($"No se encontró ningúna transaccion con ID: {id}.");
                return NotFound();
            }

            _transaccionService.UpdateTransaccion(transaccion);

            return Ok(transaccion);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar la transaccion con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete(Name = "DeleteTransaccion")]
    public IActionResult DeleteTransaccion(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar la transaccion con ID: {id}.");

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, id))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {id}.");
                return Forbid();
            }

            var user = _transaccionService.GetIdTransaccion(id);

            if (user is null)
            {
                _logger.LogWarning($"No se encontró ningúna transaccion con ID: {id}.");
                return NotFound();
            }

            _transaccionService.DeleteTransaccion(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar la transaccion con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }
}
