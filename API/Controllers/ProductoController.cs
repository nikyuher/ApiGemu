using Microsoft.AspNetCore.Mvc;
using Gemu.Data;
using Gemu.Models;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security;

namespace Gemu.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private readonly ILogger<ProductoController> _logger;
    private readonly IProductoService _productoService;
    private readonly IAuthService _authService;

    public ProductoController(ILogger<ProductoController> logger, IProductoService productoService, IAuthService authService)
    {
        _logger = logger;
        _productoService = productoService;
        _authService = authService;
    }


    //Read
    [AllowAnonymous]
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

    [AllowAnonymous]
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

    [AllowAnonymous]
    [HttpGet("{id}/categorias")]
    public ActionResult<ProductoCategoriasDTO> GetCategoriasProduct(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener las categorias del producto con ID: {id}.");

            var producto = _productoService.GetCategoriasProduct(id);

            if (producto == null)
            {
                _logger.LogWarning($"No se encontró ningúna categoria del producto con ID: {id}.");
                return NotFound();
            }

            return producto;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener las categorias producto con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    [AllowAnonymous]
    [HttpGet("{id}/reseñas")]
    public ActionResult<ProductoReseñaDTO> GetReseñasProducto(int id)
    {
        try
        {
            _logger.LogInformation($"Se ha solicitado obtener las reseñas del producto con ID: {id}.");

            var producto = _productoService.GetReseñasProducto(id);

            if (producto == null)
            {
                _logger.LogWarning($"No se encontró ningúna reseña del producto con ID: {id}.");
                return NotFound();
            }

            return producto;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar obtener las reseñas del producto con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

    //Create
    [HttpPost("crear")]
    public IActionResult CreateProducto([FromBody] ProductoAddDTO producto)
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

    [HttpPost("{id}/asignar-categorias")]
    public IActionResult AsignarCategoriasProducto(int id, [FromBody] List<int> ListaIdsCateogira)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para asignar categoria a usuario");

            var producto = _productoService.GetIdProducto(id);

            if (producto is null)
            {
                _logger.LogWarning($"No se encontró ningún producto con ID: {id}.");
                return NotFound();
            }

            _productoService.AsignarCategoriasProducto(id, ListaIdsCateogira);

            return Ok(producto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar asignar una categoria : {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("{id}/asignar-reseñas")]
    public IActionResult AsignarReseñaProducto(int id, [FromBody] List<int> ListaIdsReseñas)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para asignar reseña a usuario");

            var producto = _productoService.GetIdProducto(id);

            if (producto is null)
            {
                _logger.LogWarning($"No se encontró ningún producto con ID: {id}.");
                return NotFound();
            }

            _productoService.AsignarReseñaProducto(id, ListaIdsReseñas);

            return Ok(producto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar asignar una reseña: {ex.Message}");
            return BadRequest(new { message = ex.Message });
        }
    }

    //Update
    [HttpPut("{id}/datos")]
    public IActionResult UpdateProducto(int id, [FromBody] ProductoDTO producto)
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

    [HttpPut("{id}/categorias")]
    public IActionResult UpdateCategoriasProducto(int id, [FromBody] List<Categoria> ListaCategoria)
    {
        try
        {
            _logger.LogInformation($"Se ha recibido una solicitud para actualizar las categorias");

            var producto = _productoService.GetIdProducto(id);

            if (producto is null)
            {
                _logger.LogWarning($"No se encontró ningún producto con ID: {id}.");
                return NotFound();
            }

            _productoService.UpdateCategoriasProducto(id, ListaCategoria);

            return Ok(producto);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar actualizar las categorias del producto con ID {id}: {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }


    //Delete
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

    [HttpDelete("{id}/categorias")]
    public IActionResult EliminarCategoriasProducto(int id, [FromBody] List<int> ListaIdsCateogira)
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

            _productoService.EliminarCategoriasProducto(id, ListaIdsCateogira);

            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error al intentar eliminar las categorias : {ex.Message}");
            return StatusCode(500, new { message = "Ocurrió un error interno en el servidor." });
        }
    }

}
