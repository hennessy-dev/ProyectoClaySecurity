using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;
namespace Persistencia.Data.Configurations;
public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(30);
    }
}