using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ILogger<CategoriaController> _logger;
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService categoriaService)
    {
        _logger = logger;
        _categoriaService = categoriaService;
    }

    
    [HttpGet()]
    public ActionResult<List<Categoria>> GetAllCategorias()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todos los categorias.");
            return _categoriaService.GetAllCategorias();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los categorias: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Categoria> GetUsuarioId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener el categoria con ID: {id}.");

            var categoria = _categoriaService.GetIdCategoria(id);

            if (categoria == null)
            {
                _logger.LogWarning($"No se encontró ningún categoria con ID: {id}.");
                return NotFound();
            }

            return categoria;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener el categoria con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPost("crear")]
    public IActionResult CreateCategoria([FromBody] Categoria categoria)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de categoria.");

            _categoriaService.CreateCategoria(categoria);
            return Ok(categoria);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear categoria: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategoria(int id, [FromBody] Categoria categoria)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización del categoria con ID: {id}.");

            if (id != categoria.IdCategoria)
            {
                _logger.LogError("El ID del categoria en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingCategoria = _categoriaService.GetIdCategoria(id);

            if (existingCategoria is null)
            {
                _logger.LogWarning($"No se encontró ningún categoria con ID: {id}.");
                return NotFound();
            }

            _categoriaService.UpdateCategoria(categoria);

            return Ok(categoria);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar categoria con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategoria(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar el categoria con ID: {id}.");

            var categoria = _categoriaService.GetIdCategoria(id);

            if (categoria is null)
            {
                _logger.LogWarning($"No se encontró ningún categoria con ID: {id}.");
                return NotFound();
            }

            _categoriaService.DeleteCategoria(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar categoria con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }
}
