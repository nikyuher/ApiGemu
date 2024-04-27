using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BibliotecaController : ControllerBase
{
    private readonly ILogger<BibliotecaController> _logger;
    private readonly IBibliotecaService _bibliotecaService;

    public BibliotecaController(ILogger<BibliotecaController> logger, IBibliotecaService bibliotecaService)
    {
        _logger = logger;
        _bibliotecaService = bibliotecaService;
    }

    
    [HttpGet()]
    public ActionResult<List<Biblioteca>> GetAllBibliotecas()
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

    [HttpGet("{id}")]
    public ActionResult<Biblioteca> GetBiblioteId(int id)
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

            return biblioteca;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener la biblioteca con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPost("crear")]
    public IActionResult CreateBiblioteca([FromBody] Biblioteca biblioteca)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación una biblioteca.");

            _bibliotecaService.CreateBiblioteca(biblioteca);
            return Ok(biblioteca);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear una biblioteca: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

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
}
