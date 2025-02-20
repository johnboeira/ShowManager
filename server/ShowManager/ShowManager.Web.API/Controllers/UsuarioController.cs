using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShowManager.Web.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    public IActionResult CriarUsuario()
    {
    }
}