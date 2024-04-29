using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService)
    {
        _logger = logger;
        _usuarioService = usuarioService;
    }

    [HttpGet(Name = "GetAllUsuarios")]
    public ActionResult<List<UsuarioDTO>> GetAllUsuarios()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todos los usuarios.");
            return _usuarioService.GetAllUsuarios();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los usuarios: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("{id}", Name = "GetUsuario")]
    public ActionResult<UsuarioDTO> GetUsuarioId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener el usuario con ID: {id}.");

            var user = _usuarioService.GetIdUsuario(id);

            if (user == null)
            {
                _logger.LogWarning($"No se encontró ningún usuario con ID: {id}.");
                return NotFound();
            }

            return user;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener el usuario con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPost("login", Name = "LoginUsuario")]
    public IActionResult Login([FromBody] UsuarioLoginDTO loginRequest)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de inicio de sesión.");

            var usuario = _usuarioService.LoginUsuario(loginRequest);

            return Ok(usuario);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar iniciar sesión: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("registrar",Name ="CreateUsuario")]
    public IActionResult CreateUsuario([FromBody] UsuarioCreateDTO user)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de usuario.");

            _usuarioService.CreateUsuario(user);
            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear usuario: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut(Name ="PutUsuario")]
    public IActionResult UpdateUsuario(int id, [FromBody] Usuario user)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización del usuario con ID: {id}.");

            if (id != user.IdUsuario)
            {
                _logger.LogError("El ID del usuario en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingUser = _usuarioService.GetIdUsuario(id);

            if (existingUser is null)
            {
                _logger.LogWarning($"No se encontró ningún usuario con ID: {id}.");
                return NotFound();
            }

            _usuarioService.UpdateUsuario(user);

            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar usuario con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPut("{id}/rol", Name ="PutRolUsuario")]
    public IActionResult UpdateRolUsuario(int id, [FromBody] UsuarioUpdateDTO user)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización de rol del usuario con ID: {id}.");

            if (id != user.IdUsuario)
            {
                _logger.LogError("El ID del usuario en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingUser = _usuarioService.GetIdUsuario(id);

            if (existingUser is null)
            {
                _logger.LogWarning($"No se encontró ningún usuario con ID: {id}.");
                return NotFound();
            }

            _usuarioService.UpdateRolUsuario(user);

            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar el rol del usuario con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPut("{id}/direccion", Name ="PutDireccionUsuario")]
    public IActionResult UpdateDireccionUsuario(int id, [FromBody] UsuarioDireccionDTO user)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización direccion del usuario con ID: {id}.");

            if (id != user.IdUsuario)
            {
                _logger.LogError("El ID del usuario en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingUser = _usuarioService.GetIdUsuario(id);

            if (existingUser is null)
            {
                _logger.LogWarning($"No se encontró ningún usuario con ID: {id}.");
                return NotFound();
            }

            _usuarioService.UpdateDireccionUsuario(user);

            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar la direccion del usuario con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPut("{id}/nombre", Name ="PutNombreUsuario")]
    public IActionResult UpdateInfoUsuario(int id, [FromBody] UsuarioInfoDTO user)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización informacion del usuario con ID: {id}.");

            if (id != user.IdUsuario)
            {
                _logger.LogError("El ID del usuario en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingUser = _usuarioService.GetIdUsuario(id);

            if (existingUser is null)
            {
                _logger.LogWarning($"No se encontró ningún usuario con ID: {id}.");
                return NotFound();
            }

            _usuarioService.UpdateInfoUsuario(user);

            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar la informacion del usuario con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPut("{id}/foto-perfil", Name ="PutFotoPerfilUsuario")]
    public IActionResult UpdateFotoUsuario(int id, [FromBody] UsuarioFotoDTO user)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización la foto del usuario con ID: {id}.");

            if (id != user.IdUsuario)
            {
                _logger.LogError("El ID del usuario en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingUser = _usuarioService.GetIdUsuario(id);

            if (existingUser is null)
            {
                _logger.LogWarning($"No se encontró ningún usuario con ID: {id}.");
                return NotFound();
            }

            _usuarioService.UpdateFotoUsuario(user);

            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar la foto del usuario con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete(Name ="DeleteUsuario")]
    public IActionResult DeleteUsuario(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar el usuario con ID: {id}.");

            var user = _usuarioService.GetIdUsuario(id);

            if (user is null)
            {
                _logger.LogWarning($"No se encontró ningún usuario con ID: {id}.");
                return NotFound();
            }

            _usuarioService.DeleteUsuario(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar usuario con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }
}
