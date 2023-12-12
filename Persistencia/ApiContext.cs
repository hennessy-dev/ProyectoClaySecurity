using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;
public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions options) : base(options)
    { }
    
    public DbSet<Rol> Roles { get; set; }
    public DbSet<RolUsuario> RolUsuarios { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<CategoriaPersona> CategoriaPersonas { get; set; }
    public virtual DbSet<Ciudad> Ciudades { get; set; }
    public virtual DbSet<ContactoPersona> ContactoPersonas { get; set; }
    public virtual DbSet<Contrato> Contratos { get; set; }
    public virtual DbSet<Departamento> Departamentos { get; set; }
    public virtual DbSet<DireccionPersona> DireccionPersonas { get; set; }
    public virtual DbSet<Estado> Estados { get; set; }
    public virtual DbSet<Pais> Pais { get; set; }
    public virtual DbSet<Persona> Personas { get; set; }
    public virtual DbSet<Programacion> Programaciones { get; set; }
    public virtual DbSet<RefreshToken> Refreshtokens { get; set; }
    public virtual DbSet<TipoContacto> TipoContactos { get; set; }
    public virtual DbSet<TipoDireccion> TipoDirecciones { get; set; }
    public virtual DbSet<TipoPersona> TipoPersonas { get; set; }
    public virtual DbSet<Turno> Turnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=ConnectionStrings:ConexMySql", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.35-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");


        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
