using AutoMapper;
using ShowManager.Contracts.DTOs.Features.Usuario;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Application.Features.Usuarios;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<UsuarioCriar.Command, Usuario>();
        CreateMap<UsuarioEditar.Command, Usuario>();
        CreateMap<Usuario, UsuarioDTO>();
    }
}