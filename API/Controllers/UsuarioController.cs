using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
namespace Gemu.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly ILogger<UsuarioController> _logger;
    private readonly IUsuarioService _usuarioService;
    private readonly IAuthService _authService;

    public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService, IAuthService authService)
    {
        _logger = logger;
        _usuarioService = usuarioService;
        _authService = authService;
    }

    [Authorize(Roles = "Admin")]
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

    [Authorize(Roles = "Admin")]
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

    [AllowAnonymous]
    [HttpPost("login", Name = "LoginUsuario")]
    public IActionResult Login([FromBody] UsuarioLoginDTO loginRequest)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de inicio de sesión.");

            var usuario = _usuarioService.LoginUsuario(loginRequest);

            var token = _authService.GenerateJwtToken(usuario);

            // Devolver el token al cliente
            return Ok(new { token });

            // return Ok(usuario);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar iniciar sesión: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [AllowAnonymous]
    [HttpPost("registrar", Name = "CreateUsuario")]
    public IActionResult CreateUsuario([FromBody] UsuarioCreateDTO user)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de usuario.");

            var usuario = _usuarioService.CreateUsuario(user);
            // Generar el token JWT para el nuevo usuario
            var token = _authService.GenerateJwtToken(usuario);

            // Devolver el token JWT al cliente
            return Ok(new { token });

            // return Ok(usuario);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear usuario: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut(Name = "PutUsuario")]
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

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, id))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para modificar el usuario con ID: {id}.");
                return Forbid();
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

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}/rol", Name = "PutRolUsuario")]
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

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, id))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para modificar el usuario con ID: {id}.");
                return Forbid();
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

    [HttpPut("{id}/direccion", Name = "PutDireccionUsuario")]
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

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, id))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para modificar el usuario con ID: {id}.");
                return Forbid();
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

    [HttpPut("{id}/nombre", Name = "PutNombreUsuario")]
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

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, id))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para modificar el usuario con ID: {id}.");
                return Forbid();
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

    [HttpPut("{id}/foto-perfil", Name = "PutFotoPerfilUsuario")]
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

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, id))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para modificar el usuario con ID: {id}.");
                return Forbid();
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

    [HttpDelete(Name = "DeleteUsuario")]
    public IActionResult DeleteUsuario(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar el usuario con ID: {id}.");

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, id))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {id}.");
                return Forbid();
            }

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
