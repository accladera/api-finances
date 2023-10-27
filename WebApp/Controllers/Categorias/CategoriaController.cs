using Application.UseCases.Commands.Categorias.ActualizarCategoria;
using Application.UseCases.Commands.Categorias.EliminarCategoria;
using Application.UseCases.Commands.Categorias.RegistrarCategoria;
using Application.UseCases.Query.Categorias.GetCategoriasByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Categorias;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ILogger<CategoriaController> _logger;
    private readonly IMediator _mediator;

    public CategoriaController(IMediator mediator, ILogger<CategoriaController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CrearCategoria([FromBody] RegistrarCategoriaCommand command)
    {
        try
        {
            var resultGuid = await _mediator.Send(command);
            return Ok(resultGuid);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al registrar la categoría");
            return StatusCode(500, ex.Message);
        }
    }
    

    [HttpPut]
    public async Task<IActionResult> ActualizarCategoria([FromBody] ActualizarCategoriaCommand command)
    {
        try
        {
            var resultGuid = await _mediator.Send(command);
            return Ok(resultGuid);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al registrar la categoría");
            return StatusCode(500, ex.Message);
        }
    }

    [Route("byUser")]
    [HttpPost]
    public async Task<IActionResult> ListaCategoriasDelUsuario([FromBody] GetCategoriasByUserIdQuery query)
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


    [HttpDelete]
    public async Task<ActionResult> EliminarCategoria([FromBody] ElimiarCategoriaCommand command)
    {
        try
        {
            var resultGuid = await _mediator.Send(command);
            return Ok(resultGuid);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al eliminar el categoría");
            return BadRequest();
        }
    }


}