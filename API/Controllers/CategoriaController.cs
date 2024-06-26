using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Gemu.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ILogger<CategoriaController> _logger;
    private readonly ICategoriaService _categoriaService;
    private readonly IAuthService _authService;

    public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService categoriaService, IAuthService authService)
    {
        _logger = logger;
        _categoriaService = categoriaService;
        _authService = authService;
    }

    [AllowAnonymous]
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

    [AllowAnonymous]
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
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [AllowAnonymous]
    [HttpGet("seccion")]
    public ActionResult<List<Categoria>> GetCategoriasSeccion(string nombre)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener todas las categorias de la seccion: {nombre}");

            var categorias = _categoriaService.GetCategoriaSeccion(nombre);

            if (categorias is null)
            {
                _logger.LogWarning($"No se existe ninguna seccion llamada: {nombre}");
                return NotFound();
            }

            return Ok(categorias);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los categorias: {ex.Message}");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Admin")]
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

    [Authorize(Roles = "Admin")]
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
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Admin")]
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
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
