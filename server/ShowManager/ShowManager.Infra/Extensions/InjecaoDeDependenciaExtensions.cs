using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShowManager.Infra.Criptografia;

namespace ShowManager.Infra.Extensions;

public static class InjecaoDeDependenciaExtensions
{
    public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        var chaveAdicional = configuration.GetValue<string>("Settings:Password:AdditionalKey")
            ?? throw new InvalidOperationException("Connection string não encontrada!");

        services.AddScoped(opt => new SenhaEncriptador(chaveAdicional!));
    }
}