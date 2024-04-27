using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class JuegoController : ControllerBase
{
    private readonly ILogger<JuegoController> _logger;
    private readonly IJuegoService _juegoService;

    public JuegoController(ILogger<JuegoController> logger, IJuegoService juegoService)
    {
        _logger = logger;
        _juegoService = juegoService;
    }

    
    [HttpGet()]
    public ActionResult<List<Juego>> GetAllJuegos()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todos los juegos.");
            return _juegoService.GetAllJuegos();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los juegos: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Juego> GetJuegoId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener el juego con ID: {id}.");

            var juego = _juegoService.GetIdJuego(id);

            if (juego == null)
            {
                _logger.LogWarning($"No se encontró ningún juego con ID: {id}.");
                return NotFound();
            }

            return juego;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener el juego con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPost("crear")]
    public IActionResult CreateJuego([FromBody] Juego juego)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de juego.");

            _juegoService.CreateJuego(juego);
            return Ok(juego);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear juego: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateJuego(int id, [FromBody] Juego juego)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización del juego con ID: {id}.");

            if (id != juego.IdJuego)
            {
                _logger.LogError("El ID del juego en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingJuego = _juegoService.GetIdJuego(id);

            if (existingJuego is null)
            {
                _logger.LogWarning($"No se encontró ningún juego con ID: {id}.");
                return NotFound();
            }

            _juegoService.UpdateJuego(juego);

            return Ok(juego);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar juego con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteJuego(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar el juego con ID: {id}.");

            var juego = _juegoService.GetIdJuego(id);

            if (juego is null)
            {
                _logger.LogWarning($"No se encontró ningún juego con ID: {id}.");
                return NotFound();
            }

            _juegoService.DeleteJuego(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar juego con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }
}
