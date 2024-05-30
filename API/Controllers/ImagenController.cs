using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Gemu.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ImagenController : ControllerBase
{
    private readonly ILogger<ImagenController> _logger;
    private readonly IImagenService _imagenService;
    private readonly IAuthService _authService;

    public ImagenController(ILogger<ImagenController> logger, IImagenService imagenService, IAuthService authService)
    {
        _logger = logger;
        _imagenService = imagenService;
        _authService = authService;
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

    [AllowAnonymous]
    [HttpGet("juego")]
    public ActionResult<List<ImagenJuegoDTO>> GetImagenesJuego(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener el imagen del producto con ID: {id}.");

            var imagen = _imagenService.GetImagenesJuego(id);

            if (imagen == null)
            {
                _logger.LogWarning($"No se encontró ningún imagen del producto con ID: {id}.");
                return NotFound();
            }

            return imagen;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener el imagen del producto con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [AllowAnonymous]
    [HttpGet("producto")]
    public ActionResult<List<ImagenProductoDTO>> GetImagenesProducto(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener el imagen del producto con ID: {id}.");

            var imagen = _imagenService.GetImagenesProducto(id);

            if (imagen == null)
            {
                _logger.LogWarning($"No se encontró ningún imagen del producto con ID: {id}.");
                return NotFound();
            }

            return imagen;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener el imagen del producto con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    //Create
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

    [HttpPost("producto")]
    public IActionResult CreateImagenProducto([FromBody] List<ImagenProductoDTO> imagen)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de imagenes.");

            _imagenService.CreateImagenProducto(imagen);
            return Ok(imagen);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear imagen: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("juego")]
    public IActionResult CreateImagenJuego([FromBody] List<ImagenJuegoDTO> imagen)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de imagenes.");

            _imagenService.CreateImagenJuego(imagen);
            return Ok(imagen);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear imagen: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }


    //Update
    [HttpPut("producto")]
    public IActionResult UpdateImagenProducto([FromBody] List<ImagenProductoDTO> imagen)
    {
        try
        {
            foreach (var item in imagen)
            {
                _logger.LogInformation($"Se ha recibido una solicitud actualizar imagene con ID: {item.Id}.");

                var existingImagen = _imagenService.GetIdImagen(item.Id);

                if (existingImagen is null)
                {
                    _logger.LogWarning($"No se encontró ningún imagen con ID: {item.Id}.");
                    return NotFound();
                }
            }

            _imagenService.UpdateImagenProducto(imagen);

            return Ok(imagen);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar imagenes : {ex.Message}");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("juego")]
    public IActionResult UpdateImagenJuego([FromBody] List<ImagenJuegoDTO> imagen)
    {
        try
        {
            foreach (var item in imagen)
            {
                _logger.LogInformation($"Se ha recibido una solicitud actualizar imagene con ID: {item.Id}.");

                var existingImagen = _imagenService.GetIdImagen(item.Id);

                if (existingImagen is null)
                {
                    _logger.LogWarning($"No se encontró ningún imagen con ID: {item.Id}.");
                    return NotFound();
                }
            }

            _imagenService.UpdateImagenJuego(imagen);

            return Ok(imagen);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar imagenes : {ex.Message}");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    //Delete
    [HttpDelete("producto")]
    public IActionResult DeleteImagenesProducto([FromBody] int idProducto)
    {
        try
        {

            _logger.LogInformation($"Se ha recibido una solicitud para eliminar imagenes del producto con ID: {idProducto}.");

            _imagenService.DeleteImagenesProducto(idProducto);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar imagenes: {ex.Message}");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpDelete("juego")]
    public IActionResult DeleteImagenesJuego([FromBody] int idJuego)
    {
        try
        {

            _logger.LogInformation($"Se ha recibido una solicitud para eliminar imagenes del juego con ID: {idJuego}.");

            _imagenService.DeleteImagenesJuego(idJuego);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar imagenes: {ex.Message}");
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
