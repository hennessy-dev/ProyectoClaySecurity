using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;
namespace Persistencia.Data.Configurations;
public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("refreshtoken");

            entity.HasIndex(e => e.IdUsuarioFk, "IdUsuario_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Expires).HasColumnType("datetime");
            entity.Property(e => e.Revoked).HasMaxLength(45);
            entity.Property(e => e.Token).HasMaxLength(255);

            entity.HasOne(d => d.IdUsuarioFkNavigation).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.IdUsuarioFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdUsuarioFK");
    }
}