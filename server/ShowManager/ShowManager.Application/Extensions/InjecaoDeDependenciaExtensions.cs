using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShowManager.Application.Features.Usuarios;

namespace ShowManager.Application.Extensions;

public static class InjecaoDeDependenciaExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        services.AddMediatR(assemblies);
        services.AddAutoMapper(assemblies);
        services.AddValidatorsFromAssemblyContaining<BuscaUsuarioPorId.Query>();
    }
}