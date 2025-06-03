using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShowManager.Application.Features.Usuarios;

namespace ShowManager.Web.API.Features.Usuarios;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] UsuarioCriar.Command command)
    {
        await mediator.Send(command);

        return Ok();
    }

    [Route("{id:int}")]
    [HttpGet]
    public async Task<IActionResult> ObterPorId([FromRoute] int id)
    {
        var resultado = await mediator.Send(new BuscaUsuarioPorId.Query(id));

        return Ok(resultado);
    }

    [HttpPut]
    public async Task<IActionResult> Editar([FromBody] UsuarioEditar.Command command)
    {
        var resultado = await mediator.Send(command);

        return Ok(resultado);
    }

    //[Route("{id}")]
    //[HttpDelete]
    //public async Task<IActionResult> Delete([FromRoute] int id)
    //{
    //    //await usuarioService.DeletarAsync(id);

    //    return Ok();
    //}
}