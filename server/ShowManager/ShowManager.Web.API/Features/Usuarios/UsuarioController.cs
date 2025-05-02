using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Exceptions.Excecoes;

namespace ShowManager.Web.API.Features.Usuarios;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController(IMapper mapper) : ControllerBase
{
    [Route("CriarUsuario")]
    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] UsuarioAdicionarDTO usuarioAdicionarDTO)
    {
        var usuario = mapper.Map<Usuario>(usuarioAdicionarDTO);

        //await usuarioService.CriarAsync(usuario);

        return Ok();
    }

    //[Route("ObterPorID/{id}")]
    //[HttpGet]
    //public async Task<IActionResult> ObterPorId([FromRoute] int id)
    //{
    //    //var usuario = await usuarioService.BuscarPorIDAsync(id);

    //    return Ok(usuario);
    //}

    [Route("EditarUsuario")]
    [HttpPut]
    public async Task<IActionResult> Editar([FromBody] UsuarioEditarDTO usuarioEditarDTO)
    {
        throw new NaoEncontradoExcecao($"Usuário não encontrado, id: {usuarioEditarDTO.Id}");

        var usuario = mapper.Map<Usuario>(usuarioEditarDTO);

        //await usuarioService.AtualizarAsync(usuario);

        return Ok();
    }

    [Route("Delete/{id}")]
    [HttpDelete]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        //await usuarioService.DeletarAsync(id);

        return Ok();
    }
}