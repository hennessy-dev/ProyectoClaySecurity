using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;
namespace Persistencia.Data.Configurations;
public class CategoriaPersonaConfiguration : IEntityTypeConfiguration<CategoriaPersona>
{
    public void Configure(EntityTypeBuilder<CategoriaPersona> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categoriapersona");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreCategoria).HasMaxLength(60);
    }
}