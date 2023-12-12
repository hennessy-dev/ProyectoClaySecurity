using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;
namespace Persistencia.Data.Configurations;
public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("departamento");

            entity.HasIndex(e => e.IdPaisFk, "IdPaisFk_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreDep).HasMaxLength(50);

            entity.HasOne(d => d.IdPaisFkNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdPaisFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdPaisFk");
    }
}