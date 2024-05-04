using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ReseñaController : ControllerBase
{
    private readonly ILogger<ReseñaController> _logger;
    private readonly IReseñaService _reseñaService;

    public ReseñaController(ILogger<ReseñaController> logger, IReseñaService reseñaService)
    {
        _logger = logger;
        _reseñaService = reseñaService;
    }



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

    [HttpPost("crear")]
    public IActionResult CreateReseña([FromBody] ReseñaAddDTO reseña)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de la reseña.");

            _reseñaService.CreateReseña(reseña);
            return Ok(reseña);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear la reseña: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
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

    [HttpDelete("{id}")]
    public IActionResult DeleteReseña(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar la reseña con ID: {id}.");

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
