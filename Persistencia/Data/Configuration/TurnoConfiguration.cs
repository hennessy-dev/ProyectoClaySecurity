using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dominio.Entities;
namespace Persistencia.Data.Configurations;
public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
{
    public void Configure(EntityTypeBuilder<Turno> entity)
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("turno");

            entity.Property(e => e.HoraFinal).HasColumnType("datetime");
            entity.Property(e => e.HoraInicio).HasColumnType("datetime");
            entity.Property(e => e.NombreTurno).HasMaxLength(45);
    }
}