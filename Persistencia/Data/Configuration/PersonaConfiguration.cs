using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;
namespace Persistencia.Data.Configurations;
public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("persona");

            entity.HasIndex(e => e.IdCategoriaPersonaFk, "IdCategoriaPersonaFk_idx");

            entity.HasIndex(e => e.IdCiudaFk, "IdCiudadFk_idx");

            entity.HasIndex(e => e.IdTipoPersonaFk, "IdTipoPersonaFk_idx");

            entity.HasIndex(e => e.IdPersonaU, "idPersonaU_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Apellido).HasMaxLength(45);
            entity.Property(e => e.Apellido2).HasMaxLength(45);
            entity.Property(e => e.IdPersonaU).HasColumnName("idPersonaU");
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.Nombre2).HasMaxLength(45);

            entity.HasOne(d => d.IdCategoriaPersonaFkNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCategoriaPersonaFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdCategoriaPersonaFk");

            entity.HasOne(d => d.IdCiudaFkNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCiudaFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdCiudadFk");

            entity.HasOne(d => d.IdTipoPersonaFkNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoPersonaFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdTipoPersonaFk");
    }
}