using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TransaccionController : ControllerBase
{
    private readonly ILogger<TransaccionController> _logger;
    private readonly ITransaccionService _transaccionService;

    public TransaccionController(ILogger<TransaccionController> logger, ITransaccionService transaccionService)
    {
        _logger = logger;
        _transaccionService = transaccionService;
    }

        [HttpGet()]
    public ActionResult<List<Transaccion>> GetAllTransacciones()
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

    [HttpGet("{id}")]
    public ActionResult<Transaccion> GetTransaccionId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener la transaccion con ID: {id}.");

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

    [HttpPost("crear")]
    public IActionResult CreateTransaccion([FromBody] Transaccion transaccion)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de una transaccion.");

            _transaccionService.CreateTransaccion(transaccion);
            return Ok(transaccion);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear una transaccion: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
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

    [HttpDelete("{id}")]
    public IActionResult DeleteTransaccion(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar la transaccion con ID: {id}.");

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
