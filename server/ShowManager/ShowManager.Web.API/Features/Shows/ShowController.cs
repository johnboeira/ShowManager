using Microsoft.AspNetCore.Mvc;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Shows;

namespace ShowManager.Web.API.Features.Shows
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController(IShowService showService) : ControllerBase
    {
        [Route("CriarShow")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ShowAdicionarDTO showAdicionarDTO)
        {
            return Ok(await showService.Criar(showAdicionarDTO));
        }

        [Route("ObterPorID/{id}")]
        [HttpGet]
        public async Task<IActionResult> ObterPorID([FromRoute] int id)
        {
            return Ok(await showService.BuscarPorID(id));
        }

        [Route("ObterTodos")]
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await showService.Buscar());
        }

        [Route("EditarShow/{id}")]
        [HttpPost]
        public async Task<IActionResult> Editar([FromBody] ShowEditarDTO showEditarDTO, int id)
        {
            return Ok(await showService.Atualizar(showEditarDTO, id));
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await showService.Deletar(id));
        }
    }
}