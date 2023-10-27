using Application.UseCases.Commands.Categorias.EliminarCategoria;
using Application.UseCases.Commands.Cuentas.CrearCuenta;
using Application.UseCases.Commands.Movimientos.CrearMovimiento;
using Application.UseCases.Commands.Movimientos.EliminarMovimiento;
using Application.UseCases.Query.Categorias.GetCategoriasByUserId;
using Application.UseCases.Query.Movimientos.GetBalanceByMonth;
using Application.UseCases.Query.Movimientos.GetMovimientosByCuentaId;
using Application.UseCases.Query.Movimientos.GetMovimientosByFilters;
using Application.UseCases.Query.Movimientos.GetMovimientosByUserId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Movimientos
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {


        private readonly ILogger<MovimientoController> _logger;
        private readonly IMediator _mediator;

        public MovimientoController(IMediator mediator, ILogger<MovimientoController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovimiento([FromBody] CrearMovimientoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
            return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el movimiento");
                return BadRequest(ex.Message);
            }
        }

        [Route("byUser")]
        [HttpPost]
        public async Task<IActionResult> ListaMovimientoDelUsuario([FromBody] GetMovimientosByUserIdQuery query)
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
                _logger.LogError(ex, "Error al obtener movimientos por usuario");
                return BadRequest(ex.Message);
            }
        }


        [Route("byAccount")]
        [HttpPost]
        public async Task<IActionResult> ListaMovimientoDeLaCuenta([FromBody] GetMovimientosByCuentaIdQuery query)
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
                _logger.LogError(ex, "Error al obtener movimientos por cuenta");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> EliminarMovimiento([FromBody] EliminarMovimientoCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el movimiento");
                return BadRequest();
            }
        }

        [Route("balance")]
        [HttpPost]
        public async Task<IActionResult> BalanceDeMovimientos([FromBody] GetBalanceByMonthQuery query)
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
                _logger.LogError(ex, "Error al obtener el balance");
                return BadRequest(ex.Message);
            }
        }

        [Route("search")]
        [HttpPost]
        public async Task<IActionResult> ListaMovimientoByGeneralFilters([FromBody] GetMovimientosByFilterGeneralQuery query)
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
                _logger.LogError(ex, "Error al obtener movimientos");
                return BadRequest(ex.Message);
            }
        }
    }
}
