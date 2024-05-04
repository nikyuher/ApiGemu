using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AnuncioController : ControllerBase
{
    private readonly ILogger<AnuncioController> _logger;
    private readonly IAnuncioService _anuncioService;

    public AnuncioController(ILogger<AnuncioController> logger, IAnuncioService anuncioService)
    {
        _logger = logger;
        _anuncioService = anuncioService;
    }


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

    [HttpGet("usuario")]
    public ActionResult<List<AnuncioDTO>> GetAnunciosUsuario(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener todos los anuncios del usuario {id}.");
            return _anuncioService.GetAnunciosUsuario(id);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los anuncios del usuario {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

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

    [HttpPost("crear")]
    public IActionResult CreateAnuncio([FromBody] Anuncio anuncio)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de anuncio.");

            _anuncioService.CreateAnuncio(anuncio);
            return Ok(anuncio);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear anuncio: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

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
