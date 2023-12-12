using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;
namespace Persistencia.Data.Configurations;
public class ContactoPersonaConfiguration : IEntityTypeConfiguration<ContactoPersona>
{
    public void Configure(EntityTypeBuilder<ContactoPersona> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contactopersona");

            entity.HasIndex(e => e.Descripcion, "Descripcion_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdPersonaFk, "IdPersona_idx");

            entity.HasIndex(e => e.IdTipoContactoFk, "IdTipoContactoFk_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion).HasMaxLength(60);

            entity.HasOne(d => d.IdPersonaFkNavigation).WithMany(p => p.ContactoPersonas)
                .HasForeignKey(d => d.IdPersonaFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdPersona");

            entity.HasOne(d => d.IdTipoContactoFkNavigation).WithMany(p => p.ContactoPersonas)
                .HasForeignKey(d => d.IdTipoContactoFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdTipoContactoFk");
    }
}