using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.DTOMapping
{
    public class EmpresaDTOMapping : IEntityTypeConfiguration<EmpresaDTO>
    {
        public void Configure(EntityTypeBuilder<EmpresaDTO> entity)
        {
            entity.HasKey(e => e.IdEmp)
                    .HasName("PK_NIS_EMPRESA_ID_EMP");

            entity.ToTable("NIS_EMPRESA");

            entity.HasIndex(e => e.RazonSocial)
                .HasName("UQ_NIS_EMPRESA_RAZON_SOCIAL")
                .IsUnique();

            entity.HasIndex(e => e.Ruc)
                .HasName("UQ_NIS_EMPRESA_RUC")
                .IsUnique();

            entity.Property(e => e.IdEmp).HasColumnName("ID_EMP");

            entity.Property(e => e.Correo)
                .HasColumnName("CORREO")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Departamento)
                .HasColumnName("DEPARTAMENTO")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Direccion)
                .IsRequired()
                .HasColumnName("DIRECCION")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Distrito)
                .HasColumnName("DISTRITO")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.FechaInicio)
                .HasColumnName("FECHA_INICIO")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaRegistro)
                .HasColumnName("FECHA_REGISTRO")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Observacion)
                .HasColumnName("OBSERVACION")
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.PaginaWeb)
                .HasColumnName("PAGINA_WEB")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Pais)
                .HasColumnName("PAIS")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.RazonSocial)
                .IsRequired()
                .HasColumnName("RAZON_SOCIAL")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Ruc)
                .IsRequired()
                .HasColumnName("RUC")
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Telefono)
                .HasColumnName("TELEFONO")
                .HasMaxLength(15)
                .IsUnicode(false);

        }
    }
}
