using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;
namespace Persistencia.Data.Configurations;
public class DireccionPersonaConfiguration : IEntityTypeConfiguration<DireccionPersona>
{
    public void Configure(EntityTypeBuilder<DireccionPersona> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("direccionpersona");

            entity.HasIndex(e => e.IdPersonaFk, "IdPersonaFk_idx");

            entity.HasIndex(e => e.IdTipoDireccionFk, "IdTipoDireccionFk_idx");

            entity.Property(e => e.Direccion).HasMaxLength(200);

            entity.HasOne(d => d.IdPersonaFkNavigation).WithMany(p => p.DireccionPersonas)
                .HasForeignKey(d => d.IdPersonaFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdPersonaFk");

            entity.HasOne(d => d.IdTipoDireccionFkNavigation).WithMany(p => p.DireccionPersonas)
                .HasForeignKey(d => d.IdTipoDireccionFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdTipoDireccionFk");
    }
}