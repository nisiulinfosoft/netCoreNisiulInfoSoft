using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace NisiulInfoSoft.DTOMapping
{
    public class UsuarioDTOMapping : IEntityTypeConfiguration<UsuarioDTO>
    {
        public void Configure(EntityTypeBuilder<UsuarioDTO> entity)
        {
            entity.HasKey(e => e.IdUsu)
                    .HasName("PK_NIS_USUARIO_ID_USU");

            entity.ToTable("NIS_USUARIO");

            entity.HasIndex(e => e.Usuario)
                .HasName("UQ_NIS_USUARIO_USUARIO")
                .IsUnique();

            entity.Property(e => e.IdUsu).HasColumnName("ID_USU");

            entity.Property(e => e.Contrasenia)
                .HasColumnName("CONTRASENIA")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.IdPer).HasColumnName("ID_PER");

            entity.Property(e => e.IdTip).HasColumnName("ID_TIP");

            entity.Property(e => e.Usuario)
                .IsRequired()
                .HasColumnName("USUARIO")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Personal)
                .WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdPer)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.TipoUsuario)
                .WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdTip)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
