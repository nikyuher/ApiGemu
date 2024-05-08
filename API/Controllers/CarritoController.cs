using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Gemu.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CarritoController : ControllerBase
{
    private readonly ILogger<CarritoController> _logger;
    private readonly ICarritoService _carritoService;
    private readonly IAuthService _authService;

    public CarritoController(ILogger<CarritoController> logger, ICarritoService carritoService, IAuthService authService)
    {
        _logger = logger;
        _carritoService = carritoService;
        _authService = authService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public ActionResult<List<Carrito>> GetAllCarritos()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todos los carritos.");
            return _carritoService.GetAllCarritos();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los carritos: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public ActionResult<Carrito> GetCarritoId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener el carrito con ID: {id}.");

            var carrito = _carritoService.GetIdCarrito(id);

            if (carrito == null)
            {
                _logger.LogWarning($"No se encontró ningún carrito con ID: {id}.");
                return NotFound();
            }

            return carrito;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener el carrito con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("usuario")]
    public ActionResult<CarritoListaDTO> GetCarritoUsuario(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener el carrito con ID: {id}.");

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, id))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {id}.");
                return Forbid();
            }

            var biblioteca = _carritoService.GetCarritoUsuario(id);

            if (biblioteca == null)
            {
                _logger.LogWarning($"No se encontró ningúna carrito con ID: {id}.");
                return NotFound();
            }

            return Ok(biblioteca);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener el carrito con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPost("asignar-usuario")]
    public IActionResult CreateCarritoUsuario([FromBody] CarritoDTO carrito)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de carrito.");

            // Obtener el usuario autenticado
            var currentUser = HttpContext.User;

            // Verificar si el usuario tiene acceso al recurso
            if (!_authService.HasAccessToResource(currentUser, carrito.IdUsuario))
            {
                _logger.LogWarning($"El usuario con ID: {currentUser.FindFirst(JwtRegisteredClaimNames.Sub)?.Value} no tiene acceso para eliminar el usuario con ID: {carrito.IdCarrito}.");
                return Forbid();
            }

            _carritoService.CreateCarritoUsuario(carrito);
            return Ok(carrito);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear carrito: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("{id}/añadir-producto")]
    public IActionResult AñadirProductoCarrito(int id, [FromBody] List<int> producto)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de añadir un producto al carrito.");

            _carritoService.AñadirProductoCarrito(id, producto);
            return Ok(producto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar añadir un producto al carrito: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("{id}/añadir-juego")]
    public IActionResult AñadirJuegoCarrito(int id, [FromBody] List<int> juego)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de añadir un juego al carrito.");

            _carritoService.AñadirJuegoCarrito(id, juego);
            return Ok(juego);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar añadir un juego al carrito: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public IActionResult UpdateCarrito(int id, [FromBody] Carrito carrito)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización del carrito con ID: {id}.");

            if (id != carrito.IdCarrito)
            {
                _logger.LogError("El ID del carrito en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingCarrito = _carritoService.GetIdCarrito(id);

            if (existingCarrito is null)
            {
                _logger.LogWarning($"No se encontró ningún carrito con ID: {id}.");
                return NotFound();
            }

            _carritoService.UpdateCarrito(carrito);

            return Ok(carrito);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar carrito con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public IActionResult DeleteCarrito(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar el carrito con ID: {id}.");

            var carrito = _carritoService.GetIdCarrito(id);

            if (carrito is null)
            {
                _logger.LogWarning($"No se encontró ningún carrito con ID: {id}.");
                return NotFound();
            }

            _carritoService.DeleteCarrito(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar carrito con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete("{id}/producto")]
    public IActionResult EliminarProductoCarrito(int id, int idProduct)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar un producto con ID: {id}.");

            var user = _carritoService.GetIdCarrito(id);

            if (user is null)
            {
                _logger.LogWarning($"No se encontró ningún carrito con ID: {id}.");
                return NotFound();
            }

            _carritoService.EliminarProductoCarrito(id, idProduct);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar un producto del carrito con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete("{id}/juego")]
    public IActionResult EliminarJuegoCarrito(int id, int idJuego)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar un juego con ID: {id}.");

            var user = _carritoService.GetIdCarrito(id);

            if (user is null)
            {
                _logger.LogWarning($"No se encontró ningún carrito con ID: {id}.");
                return NotFound();
            }

            _carritoService.EliminarJuegoCarrito(id, idJuego);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar un juego del carrito con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }
}
