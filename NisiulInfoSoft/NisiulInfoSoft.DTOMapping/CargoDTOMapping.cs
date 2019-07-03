using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NisiulInfoSoft.DTOMapping
{
    public class CargoDTOMapping : IEntityTypeConfiguration<CargoDTO>
    {
        public void Configure(EntityTypeBuilder<CargoDTO> entity)
        {
            entity.HasKey(e => e.IdCar)
                    .HasName("PK_NIS_CARGO_ID_CAR");

            entity.ToTable("NIS_CARGO");

            entity.HasIndex(e => e.Descripcion)
                .HasName("UQ_NIS_CARGO_DESCRIPCION")
                .IsUnique();

            entity.Property(e => e.IdCar).HasColumnName("ID_CAR");

            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasColumnName("DESCRIPCION")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.Observacion)
                .HasColumnName("OBSERVACION")
                .HasMaxLength(200)
                .IsUnicode(false);

        }
    }
}
