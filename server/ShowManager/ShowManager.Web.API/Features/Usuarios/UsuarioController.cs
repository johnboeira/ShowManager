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

    //[Route("{id}")]
    //[HttpGet]
    //public async Task<IActionResult> ObterPorId([FromRoute] int id)
    //{
    //    //var usuario = await usuarioService.BuscarPorIDAsync(id);

    //    return Ok(usuario);
    //}

    //[HttpPut]
    //public async Task<IActionResult> Editar([FromBody] UsuarioEditarDTO usuarioEditarDTO)
    //{
    //    throw new NaoEncontradoExcecao($"Usuário não encontrado, id: {usuarioEditarDTO.Id}");

    //    var usuario = mapper.Map<Usuario>(usuarioEditarDTO);

    //    //await usuarioService.AtualizarAsync(usuario);

    //    return Ok();
    //}

    //[Route("{id}")]
    //[HttpDelete]
    //public async Task<IActionResult> Delete([FromRoute] int id)
    //{
    //    //await usuarioService.DeletarAsync(id);

    //    return Ok();
    //}
}