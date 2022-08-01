using FourTask_Lucas.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FourTask_Lucas.Models;


namespace FourTask_Lucas.Areas.Identity.Data;

public class FourTask_LucasContext : IdentityDbContext<Usuario>
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Equipe> Equipes { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }

    public FourTask_LucasContext(DbContextOptions<FourTask_LucasContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
