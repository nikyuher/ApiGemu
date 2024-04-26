using Microsoft.AspNetCore.Mvc;
using Gemu.Data;

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
}
