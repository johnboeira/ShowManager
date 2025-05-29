using Microsoft.EntityFrameworkCore;
using ShowManager.Dominio.Features.Apresentadores;
using ShowManager.Dominio.Features.Espectadores;
using ShowManager.Dominio.Features.Organizadores;
using ShowManager.Dominio.Features.Patrocinadores;
using ShowManager.Dominio.Features.Shows;
using ShowManager.Dominio.Features.Usuarios;

namespace ShowManager.Infra.Shared;

public class ShowManagerContext : DbContext
{
    public ShowManagerContext(DbContextOptions<ShowManagerContext> options) : base(options)
    {
    }

    public DbSet<Organizador> Organizadores { get; set; }
    public DbSet<Apresentador> Apresentadores { get; set; }
    public DbSet<Espectador> Espectadores { get; set; }
    public DbSet<Patrocinador> Patrocinadores { get; set; }
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Assembly.GetExecutingAssembly()
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShowManagerContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}