using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShowManager.Aplicacao.Features.Organizadores;
using ShowManager.Aplicacao.Features.Shows;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;
using ShowManager.Infra.Features.Organizadores;
using ShowManager.Infra.Features.Shows;
using ShowManager.Infra.Features.Usuarios;
using ShowManager.Infra.Shared;
using ShowManager.Web.API.Filters;

namespace ShowManager.Web.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        // Adicionando o DbContext com SQL Server
        builder.Services.AddDbContext<ShowManagerContext>(options =>
            options.UseSqlServer(connectionString));

        // Registrando os repositórios
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        builder.Services.AddAutoMapper(assemblies);

        //var assembly = AppDomain.CurrentDomain.Load("CQRS_Example.Application");
        builder.Services.AddMediatR(assemblies);

        builder.Services.AddMvc(options => options.Filters.Add(typeof(FiltroParaExcecoes)));

        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.MapOpenApi();

        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ShowManagerContext>();
            dbContext.Database.Migrate();
        }

        app.Run();
    }
}