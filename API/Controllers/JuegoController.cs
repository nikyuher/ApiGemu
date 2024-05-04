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


    //Read
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
    public ActionResult<JuegoDTO> GetJuegoId(int id)
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

    [HttpGet("{id}/categorias")]
    public ActionResult<JuegoCategoriasDTO> GetCategoriasJuego(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener las categorias del juego con ID: {id}.");

            var juego = _juegoService.GetCategoriasJuego(id);

            if (juego == null)
            {
                _logger.LogWarning($"No se encontró ningún juego con ID: {id}.");
                return NotFound();
            }

            return juego;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener las categorias juego con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("{id}/reseñas")]
    public ActionResult<JuegoReseñaDTO> GetReseñasJuego(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener las reseñas juego con ID: {id}.");

            var juego = _juegoService.GetReseñasJuego(id);

            if (juego == null)
            {
                _logger.LogWarning($"No se encontró ningún juego con ID: {id}.");
                return NotFound();
            }

            return juego;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener las reseñas del juego con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    //Create
    [HttpPost("crear")]
    public IActionResult CreateJuego([FromBody] JuegoAddDTO juego)
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

    [HttpPost("{id}/asignar-categoria")]
    public IActionResult AsignarCategoriasJuego(int id, [FromBody] List<int> ListaIdsCateogira)
    {
        try
        {

            _logger.LogInformation("Se ha recibido una solicitud asignar categorias al juego.");

            var juego = _juegoService.GetIdJuego(id);

            if (juego is null)
            {
                _logger.LogWarning($"No se encontró ningún juego con ID: {id}.");
                return NotFound();
            }

            _juegoService.AsignarCategoriasJuego(id, ListaIdsCateogira);

            return Ok(juego);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar asignar categoria al juego: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("{id}/asignar-reseña")]
    public IActionResult AsignarReseñaJuego(int id, [FromBody] List<int> ListaIdsReseñas)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de asignar reseñas al juego.");

            var juego = _juegoService.GetIdJuego(id);

            if (juego is null)
            {
                _logger.LogWarning($"No se encontró ningún juego con ID: {id}.");
                return NotFound();
            }

            _juegoService.AsignarReseñaJuego(id, ListaIdsReseñas);
            return Ok(juego);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar asignar reseñas juego: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    //Update
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

    [HttpPut("{id}/categorias")]
    public IActionResult UpdateCategoriasJuego(int id, [FromBody] List<Categoria> ListaCategoria)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización las categorias del juego con ID: {id}.");

            var juego = _juegoService.GetIdJuego(id);

            if (juego is null)
            {
                _logger.LogWarning($"No se encontró ningún juego con ID: {id}.");
                return NotFound();
            }

            _juegoService.UpdateCategoriasJuego(id, ListaCategoria);

            return Ok(juego);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar las categorias del juego con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }


    //Delete
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

    [HttpDelete("{id}/categorias")]
    public IActionResult EliminarCategoriasJuego(int id, [FromBody] List<int> ListaIdsCateogira)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar categorias del juego con ID: {id}.");

            var juego = _juegoService.GetIdJuego(id);

            if (juego is null)
            {
                _logger.LogWarning($"No se encontró ningún juego con ID: {id}.");
                return NotFound();
            }

            _juegoService.EliminarCategoriasJuego(id, ListaIdsCateogira);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar categorias del juego con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }


}
