using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;
namespace Persistencia.Data.Configurations;
public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ciudad");

            entity.HasIndex(e => e.IdDepartamentoFk, "IdDepartamentofk_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreCiudad).HasMaxLength(50);

            entity.HasOne(d => d.IdDepartamentoFkNavigation).WithMany(p => p.Ciudades)
                .HasForeignKey(d => d.IdDepartamentoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdDepartamentofk");
    }
}