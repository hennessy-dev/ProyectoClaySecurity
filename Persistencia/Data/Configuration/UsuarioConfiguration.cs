using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;
namespace Persistencia.Data.Configurations;
public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasMaxLength(60);
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);

            // entity.HasMany(d => d.Roles).WithMany(p => p.Usuari)
            //     .UsingEntity<Dictionary<string, object>>(
            //         "Rolusuario",
            //         r => r.HasOne<Rol>().WithMany()
            //             .HasForeignKey("IdRolFk")
            //             .OnDelete(DeleteBehavior.ClientSetNull)
            //             .HasConstraintName("IdRol"),
            //         l => l.HasOne<Usuario>().WithMany()
            //             .HasForeignKey("IdUsuarioFk")
            //             .OnDelete(DeleteBehavior.ClientSetNull)
            //             .HasConstraintName("IdUsuario"),
            //         j =>
            //         {
            //             j.HasKey("IdUsuarioFk", "IdRolFk")
            //                 .HasName("PRIMARY")
            //                 .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
            //             j.ToTable("rolusuario");
            //             j.HasIndex(new[] { "IdRolFk" }, "IdRol");
            //             j.IndexerProperty<int>("IdUsuarioFk").HasColumnName("idUsuarioFk");
            //             j.IndexerProperty<int>("IdRolFk").HasColumnName("idRolFk");
            //         });

            entity
           .HasMany(p => p.Roles)
           .WithMany(r => r.Usuarios)
           .UsingEntity<RolUsuario>(

               j => j
               .HasOne(pt => pt.Rol)
               .WithMany(t => t.RolesUsuarios)
               .HasForeignKey(ut => ut.IdRolFk),


               j => j
               .HasOne(et => et.Usuario)
               .WithMany(et => et.RolesUsuarios)
               .HasForeignKey(el => el.IdUsuarioFk),

               j =>
               {
                   j.ToTable("RolUsuario");
                   j.HasKey(t => new { t.IdUsuarioFk, t.IdRolFk });

               });

            entity.HasMany(p => p.RefreshTokens)
            .WithOne(p => p.IdUsuarioFkNavigation)
            .HasForeignKey(p => p.IdUsuarioFk);
        
    }
}