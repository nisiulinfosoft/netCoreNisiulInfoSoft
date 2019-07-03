using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NisiulInfoSoft.DTOMapping
{
    public class AreaDTOMapping : IEntityTypeConfiguration<AreaDTO>
    {
        public void Configure(EntityTypeBuilder<AreaDTO> entity)
        {
            entity.HasKey(e => e.IdAre)
                    .HasName("PK_NIS_AREA_ID_ARE");

            entity.ToTable("NIS_AREA");

            entity.HasIndex(e => e.Descripcion)
                .HasName("UQ_NIS_AREA_DESCRIPCION")
                .IsUnique();

            entity.Property(e => e.IdAre).HasColumnName("ID_ARE");

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
