using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;
namespace Persistencia.Data.Configurations;
public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
{
    public void Configure(EntityTypeBuilder<Programacion> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("programacion");

            entity.HasIndex(e => e.IdContratoFk, "IdContratoFk_idx");

            entity.HasIndex(e => e.IdEmpleadoFk, "IdEmpleadoFk_idx");

            entity.HasIndex(e => e.IdTurnoFk, "IdTurnoFk_idx");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.IdContratoFkNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdContratoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdContratoFk");

            entity.HasOne(d => d.IdEmpleadoFkNavigation).WithMany(p => p.Programaciones)
                .HasForeignKey(d => d.IdEmpleadoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdEmpleado");

            entity.HasOne(d => d.IdTurnoFkNavigation).WithMany(p => p.Programaciones)
                .HasForeignKey(d => d.IdTurnoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdTurnoFk");
    }
}