using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Gemu.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class BibliotecaController : ControllerBase
{
    private readonly ILogger<BibliotecaController> _logger;
    private readonly IBibliotecaService _bibliotecaService;
    private readonly IAuthService _authService;

    public BibliotecaController(ILogger<BibliotecaController> logger, IBibliotecaService bibliotecaService, IAuthService authService)
    {
        _logger = logger;
        _bibliotecaService = bibliotecaService;
        _authService = authService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public ActionResult<List<BibliotecaListaDTO>> GetAllBibliotecas()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todos las bibliotecas.");
            return _bibliotecaService.GetAllBibliotecas();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos las bibliotecas: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public ActionResult<BibliotecaListaDTO> GetBiblioteId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener la bibliote con ID: {id}.");

            var biblioteca = _bibliotecaService.GetIdBiblioteca(id);

            if (biblioteca == null)
            {
                _logger.LogWarning($"No se encontró ningúna biblioteca con ID: {id}.");
                return NotFound();
            }

            return Ok(biblioteca);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener la biblioteca con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [Authorize(Roles = "Usuario")]
    [HttpGet("usuario")]
    public ActionResult<BibliotecaListaDTO> GetBibliotecaUsuario(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener la bibliote con ID: {id}.");

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, id))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {id}.");
                return Forbid();
            }

            var biblioteca = _bibliotecaService.GetBibliotecaUsuario(id);

            if (biblioteca == null)
            {
                _logger.LogWarning($"No se encontró ningúna biblioteca con ID: {id}.");
                return NotFound();
            }

            return Ok(biblioteca);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener la biblioteca con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [Authorize(Roles = "Usuario")]
    [HttpPost("añadir-usuario")]
    public IActionResult CreateBibliotecaUsuario([FromBody] BibliotecaDTO biblioteca)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación una biblioteca.");

            _bibliotecaService.CreateBibliotecaUsuario(biblioteca);
            return Ok(biblioteca);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear una biblioteca: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Usuario")]
    [HttpPost("{id}/añadir-producto")]
    public IActionResult AñadirProductoBiblioteca(int id, [FromBody] List<int> producto)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de añadir un producto a la biblioteca.");

            _bibliotecaService.AñadirProductoBiblioteca(id, producto);
            return Ok(producto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar añadir un producto a la biblioteca: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Usuario")]
    [HttpPost("{id}/asignar-juego")]
    public IActionResult AñadirJuegoBiblioteca(int id, [FromBody] List<int> juego)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de añadir un juego a la biblioteca.");

            _bibliotecaService.AñadirJuegoBiblioteca(id, juego);
            return Ok(juego);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar añadir un juego a la biblioteca: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public IActionResult UpdateBiblioteca(int id, [FromBody] Biblioteca biblioteca)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización de la biblioteca con ID: {id}.");

            if (id != biblioteca.IdBiblioteca)
            {
                _logger.LogError("El ID de la biblioteca en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, biblioteca.IdUsuario))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {biblioteca.IdUsuario}.");
                return Forbid();
            }

            var existingBiblioteca = _bibliotecaService.GetIdBiblioteca(id);

            if (existingBiblioteca is null)
            {
                _logger.LogWarning($"No se encontró ningúna biblioteca con ID: {id}.");
                return NotFound();
            }

            _bibliotecaService.UpdateBiblioteca(biblioteca);

            return Ok(biblioteca);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar la biblioteca con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public IActionResult DeleteBiblioteca(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar la biblioteca con ID: {id}.");

            var user = _bibliotecaService.GetIdBiblioteca(id);

            if (user is null)
            {
                _logger.LogWarning($"No se encontró ningúna biblioteca con ID: {id}.");
                return NotFound();
            }

            _bibliotecaService.DeleteBiblioteca(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar la biblioteca con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [Authorize(Roles = "Usuario")]
    [HttpDelete("{id}/producto")]
    public IActionResult EliminarProductoBiblioteca(int id, int idProduct)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar un producto con ID: {id}.");

            var user = _bibliotecaService.GetIdBiblioteca(id);

            if (user is null)
            {
                _logger.LogWarning($"No se encontró ningúna biblioteca con ID: {id}.");
                return NotFound();
            }

            _bibliotecaService.EliminarProductoBiblioteca(id, idProduct);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar un producto de biblioteca con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [Authorize(Roles = "Usuario")]
    [HttpDelete("{id}/juego")]
    public IActionResult EliminarJuegoBiblioteca(int id, int idJuego)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar un juego con ID: {id}.");

            var user = _bibliotecaService.GetIdBiblioteca(id);

            if (user is null)
            {
                _logger.LogWarning($"No se encontró ningúna biblioteca con ID: {id}.");
                return NotFound();
            }

            _bibliotecaService.EliminarJuegoBiblioteca(id, idJuego);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar un juego de biblioteca con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }
}
