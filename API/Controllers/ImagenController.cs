using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagenController : ControllerBase
{
    private readonly ILogger<ImagenController> _logger;
    private readonly IImagenService _imagenService;

    public ImagenController(ILogger<ImagenController> logger, IImagenService imagenService)
    {
        _logger = logger;
        _imagenService = imagenService;
    }

    
    [HttpGet()]
    public ActionResult<List<Imagen>> GetAllImagenes()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todos los imagenes.");
            return _imagenService.GetAllImagenes();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los imagenes: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Imagen> GetImagenId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener el imagen con ID: {id}.");

            var imagen = _imagenService.GetIdImagen(id);

            if (imagen == null)
            {
                _logger.LogWarning($"No se encontró ningún imagen con ID: {id}.");
                return NotFound();
            }

            return imagen;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener el imagen con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPost("crear")]
    public IActionResult CreateImagen([FromBody] Imagen imagen)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de imagen.");

            _imagenService.CreateImagen(imagen);
            return Ok(imagen);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear imagen: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateImagen(int id, [FromBody] Imagen imagen)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización del imagen con ID: {id}.");

            if (id != imagen.Id)
            {
                _logger.LogError("El ID del imagen en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingImagen = _imagenService.GetIdImagen(id);

            if (existingImagen is null)
            {
                _logger.LogWarning($"No se encontró ningún imagen con ID: {id}.");
                return NotFound();
            }

            _imagenService.UpdateImagen(imagen);

            return Ok(imagen);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar imagen con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteImagen(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar el imagen con ID: {id}.");

            var imagen = _imagenService.GetIdImagen(id);

            if (imagen is null)
            {
                _logger.LogWarning($"No se encontró ningún imagen con ID: {id}.");
                return NotFound();
            }

            _imagenService.DeleteImagen(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar imagen con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }
}
