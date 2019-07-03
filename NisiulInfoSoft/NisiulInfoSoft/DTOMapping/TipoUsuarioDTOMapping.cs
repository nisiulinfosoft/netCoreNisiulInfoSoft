using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.DTOMapping
{
    public class TipoUsuarioDTOMapping : IEntityTypeConfiguration<TipoUsuarioDTO>
    {
        public void Configure(EntityTypeBuilder<TipoUsuarioDTO> entity)
        {
            entity.HasKey(e => e.IdTip)
                    .HasName("PK_NIS_TIPO_USUARIO_ID_TIP");

            entity.ToTable("NIS_TIPO_USUARIO");

            entity.HasIndex(e => e.Descripcion)
                .HasName("UQ_NIS_TIPO_USUARIO_DESCRIPCION")
                .IsUnique();

            entity.Property(e => e.IdTip).HasColumnName("ID_TIP");

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
