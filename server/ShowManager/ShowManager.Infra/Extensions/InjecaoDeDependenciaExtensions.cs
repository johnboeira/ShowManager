using Microsoft.Extensions.DependencyInjection;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Features.Usuarios;

namespace ShowManager.Infra.Extensions;

public static class InjecaoDeDependenciaExtensions
{
    public static void AddInfra(this IServiceCollection services)
    {
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }
}