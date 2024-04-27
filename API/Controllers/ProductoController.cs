using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;

namespace Gemu.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly ILogger<ProductoController> _logger;
    private readonly IProductoService _productoService;

    public ProductoController(ILogger<ProductoController> logger, IProductoService productoService)
    {
        _logger = logger;
        _productoService = productoService;
    }

    
    [HttpGet()]
    public ActionResult<List<Producto>> GetAllProductos()
    {
        try
        {
            _logger.LogInformation("Se ha solicitado obtener todos los productos.");
            return _productoService.GetAllProductos();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener todos los productos: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Producto> GetProductoId(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener el producto con ID: {id}.");

            var producto = _productoService.GetIdProducto(id);

            if (producto == null)
            {
                _logger.LogWarning($"No se encontró ningún producto con ID: {id}.");
                return NotFound();
            }

            return producto;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener el producto con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpPost("crear")]
    public IActionResult CreateProducto([FromBody] Producto producto)
    {
        try
        {
            _logger.LogInformation("Se ha recibido una solicitud de creación de producto.");

            _productoService.CreateProducto(producto);
            return Ok(producto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar crear producto: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProducto(int id, [FromBody] Producto producto)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud de actualización del producto con ID: {id}.");

            if (id != producto.IdProducto)
            {
                _logger.LogError("El ID del producto en el cuerpo de la solicitud no coincide con el ID en la URL.");
                return BadRequest();
            }

            var existingProducto = _productoService.GetIdProducto(id);

            if (existingProducto is null)
            {
                _logger.LogWarning($"No se encontró ningún producto con ID: {id}.");
                return NotFound();
            }

            _productoService.UpdateProducto(producto);

            return Ok(producto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar producto con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProducto(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para eliminar el producto con ID: {id}.");

            var producto = _productoService.GetIdProducto(id);

            if (producto is null)
            {
                _logger.LogWarning($"No se encontró ningún producto con ID: {id}.");
                return NotFound();
            }

            _productoService.DeleteProducto(id);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar producto con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }
}
