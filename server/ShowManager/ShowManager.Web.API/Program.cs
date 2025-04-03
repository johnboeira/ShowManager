using MediatR;

namespace ShowManager.Web.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        builder.Services.AddAutoMapper(assemblies);

        //var assembly = AppDomain.CurrentDomain.Load("CQRS_Example.Application");
        builder.Services.AddMediatR(assemblies);

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}