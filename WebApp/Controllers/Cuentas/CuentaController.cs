using Application.UseCases.Commands.Cuentas.ActualizarCuenta;
using Application.UseCases.Commands.Cuentas.CrearCuenta;
using Application.UseCases.Commands.Cuentas.EliminarCuenta;
using Application.UseCases.Query.Cuentas.GetCuentasByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]
public class CuentaController : ControllerBase
{
    private readonly ILogger<CuentaController> _logger;
    private readonly IMediator _mediator;

    public CuentaController(IMediator mediator, ILogger<CuentaController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCuenta([FromBody] CrearCuentaCommand command)
    {
        try
        {
            var resultGuid = await _mediator.Send(command);
            return Ok(resultGuid);
    }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al crear la cuenta");
            return BadRequest(ex.Message);
}
    }


    [HttpPut]
    public async Task<IActionResult> ActualizarCuenta([FromBody] ActualizarCuentaCommand command)
    {
        try
        {
            var resultGuid = await _mediator.Send(command);
            return Ok(resultGuid);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al actualizar");
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult> EliminarCategoria([FromBody] EliminarCuentaCommand command)
    {
        try
        {
            var resultGuid = await _mediator.Send(command);
            return Ok(resultGuid);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al eliminar el cuenta");
            return BadRequest();
        }
    }


    [Route("byUser")]
    [HttpPost]
    public async Task<IActionResult> ListaCuentasDelUsuario([FromBody] GetCuentasByUserIdQuery query)
    {
        try
        {
            var list = await _mediator.Send(query);

            if (list == null)
                return BadRequest();

            return Ok(list);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener categorías por usuario");
            return BadRequest(ex.Message);
        }
    }
}
