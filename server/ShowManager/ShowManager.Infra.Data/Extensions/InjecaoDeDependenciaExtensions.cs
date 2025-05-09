using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Data.Features.Usuarios;
using ShowManager.Infra.Shared;

namespace ShowManager.Infra.Extensions;

public static class InjecaoDeDependenciaExtensions
{
    public static void AddInfraData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ShowManagerContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }
}