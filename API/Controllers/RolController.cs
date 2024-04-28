using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RolController : ControllerBase
{
    private readonly ILogger<RolController> _logger;
    private readonly IRolService _rolService;

    public RolController(ILogger<RolController> logger, IRolService rolService)
    {
        _logger = logger;
        _rolService = rolService;
    }



    [HttpGet()]
    public ActionResult<List<Rol>> GetAllRoles()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todos los roles.");
            return _rolService.GetAllRoles();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los roles: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Rol> GetRolId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener el rol con ID: {id}.");

            var rol = _rolService.GetIdRol(id);

            if (rol == null)
            {
                _logger.LogWarning($"No se encontró ningún rol con ID: {id}.");
                return NotFound();
            }

            return rol;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener la rol con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPost("crear")]
    public IActionResult CreateRol([FromBody] Rol rol)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación del rol.");

            _rolService.CreateRol(rol);
            return Ok(rol);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear el rol: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRol(int id, [FromBody] Rol rol)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización del rol con ID: {id}.");

            if (id != rol.IdRol)
            {
                _logger.LogError("El ID del rol en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingReseña = _rolService.GetIdRol(id);

            if (existingReseña is null)
            {
                _logger.LogWarning($"No se encontró ningún rol con ID: {id}.");
                return NotFound();
            }

            _rolService.UpdateRol(rol);

            return Ok(rol);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar el rol con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPut("nombre")]
    public IActionResult UpdateNombreRol(int id, [FromBody] RolUpdateNombreDTO rol)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización el nombre del rol con ID: {id}.");

            if (id != rol.IdRol)
            {
                _logger.LogError("El ID del rol en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingReseña = _rolService.GetIdRol(id);

            if (existingReseña is null)
            {
                _logger.LogWarning($"No se encontró ningún rol con ID: {id}.");
                return NotFound();
            }

            _rolService.UpdateNombreRol(rol);

            return Ok(rol);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar el nombre del rol con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRol(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar el rol con ID: {id}.");

            var rol = _rolService.GetIdRol(id);

            if (rol is null)
            {
                _logger.LogWarning($"No se encontró ningún rol con ID: {id}.");
                return NotFound();
            }

            _rolService.DeleteRol(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar el rol con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }
}
