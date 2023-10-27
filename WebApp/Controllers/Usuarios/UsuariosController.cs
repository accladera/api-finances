using Application.UseCases.Commands.Usuarios.IniciarSesion;
using Application.UseCases.Commands.Usuarios.RegistrarUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Usuarios
{

    // api/usuarios
    [Route("api/user")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IMediator _mediator;


        public UsuariosController(IMediator mediator, ILogger<UsuariosController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] RegistrarUsuarioCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar al usuario.");
                return StatusCode(422, ex.Message);
            }
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> LoginUsuario([FromBody] IniciarSesionCommand command)
        {
            try
            {
                var resultGuid = await _mediator.Send(command);
                return Ok(resultGuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al ingresar al usuario.");
                return StatusCode(401, ex.Message);
            }
        }



    }
}
