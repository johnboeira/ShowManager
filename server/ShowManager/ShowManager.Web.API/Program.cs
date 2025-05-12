using Microsoft.EntityFrameworkCore;
using ShowManager.Application.Extensions;
using ShowManager.Infra.Extensions;
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

        builder.Services.AddInfra(builder.Configuration);
        builder.Services.AddInfraData(builder.Configuration);
        builder.Services.AddApplication();

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