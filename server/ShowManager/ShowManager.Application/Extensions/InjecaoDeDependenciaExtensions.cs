using Microsoft.Extensions.DependencyInjection;

namespace ShowManager.Application.Extensions;

public static class InjecaoDeDependenciaExtensions
{
    public static void AddIApplication(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        services.AddAutoMapper(assemblies);
    }
}