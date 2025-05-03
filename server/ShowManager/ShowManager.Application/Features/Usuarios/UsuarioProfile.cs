using AutoMapper;
using ShowManager.Dominio.DTO;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Application.Features.Usuarios;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UsuarioCriar.Command, Usuario>();
    }
}