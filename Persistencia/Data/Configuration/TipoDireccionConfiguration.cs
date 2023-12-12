using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;
namespace Persistencia.Data.Configurations;
public class TipoDireccionConfiguration : IEntityTypeConfiguration<TipoDireccion>
{
    public void Configure(EntityTypeBuilder<TipoDireccion> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipodireccion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(60);
    }
}