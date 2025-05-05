using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ShowManager.Application.Extensions;

public static class InjecaoDeDependenciaExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        services.AddMediatR(assemblies);
        services.AddAutoMapper(assemblies);
    }
}