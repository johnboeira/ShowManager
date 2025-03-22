using AutoMapper;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Shows;

namespace ShowManager.Web.API.Features.Shows
{
    public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            CreateMap<ShowAdicionarDTO, Show>();
            CreateMap<ShowEditarDTO, Show>();
        }
    }
}