using Microsoft.AspNetCore.Mvc;
using ShowManager.Dominio.Features.Shows;

namespace ShowManager.Web.API.Features.Shows
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController(IShowService showService) : ControllerBase
    {
    }
}