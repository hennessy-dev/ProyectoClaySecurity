using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;
namespace Persistencia.Data.Configurations;
public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
{
    public void Configure(EntityTypeBuilder<Contrato> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contrato");

            entity.HasIndex(e => e.IdCliente, "IdClienteFk_idx");

            entity.HasIndex(e => e.IdEmpleadoFk, "IdEmpleadoFk_idx");

            entity.HasIndex(e => e.IdEstadoFk, "IdEstadoFk_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaContrato).HasColumnType("datetime");
            entity.Property(e => e.FechaFin).HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ContratoIdClienteNavigations)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdClienteFk");

            entity.HasOne(d => d.IdEmpleadoFkNavigation).WithMany(p => p.ContratoIdEmpleadoFkNavigations)
                .HasForeignKey(d => d.IdEmpleadoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdEmpleadoFk");

            entity.HasOne(d => d.IdEstadoFkNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdEstadoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdEstadoFk");
    }
}