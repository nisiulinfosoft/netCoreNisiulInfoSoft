using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NisiulInfoSoft.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NisiulInfoSoft.DTOMapping
{
    public class PersonalDTOMapping : IEntityTypeConfiguration<PersonalDTO>
    {
        public void Configure(EntityTypeBuilder<PersonalDTO> entity)
        {
            entity.HasKey(e => e.IdPer)
                    .HasName("PK_NIS_PERSONAL_ID_PER");

            entity.ToTable("NIS_PERSONAL");

            entity.HasIndex(e => e.Dni)
                .HasName("UQ_NIS_PERSONAL_DNI")
                .IsUnique();

            entity.Property(e => e.IdPer).HasColumnName("ID_PER");

            entity.Property(e => e.ApellidoMaterno)
                .IsRequired()
                .HasColumnName("APELLIDO_MATERNO")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.ApellidoPaterno)
                .IsRequired()
                .HasColumnName("APELLIDO_PATERNO")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Celular)
                .HasColumnName("CELULAR")
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Correo)
                .HasColumnName("CORREO")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Direccion)
                .HasColumnName("DIRECCION")
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Dni)
                .IsRequired()
                .HasColumnName("DNI")
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.FechaContacto)
                .HasColumnName("FECHA_CONTACTO")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaNacimiento)
                .HasColumnName("FECHA_NACIMIENTO")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaRegistro)
                .HasColumnName("FECHA_REGISTRO")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.IdAre).HasColumnName("ID_ARE");

            entity.Property(e => e.IdCar).HasColumnName("ID_CAR");

            entity.Property(e => e.IdEmp).HasColumnName("ID_EMP");

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasColumnName("NOMBRE")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Observacion)
                .HasColumnName("OBSERVACION")
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Sexo)
                .IsRequired()
                .HasColumnName("SEXO")
                .HasMaxLength(1)
                .IsUnicode(false);

            entity.Property(e => e.Telefono)
                .HasColumnName("TELEFONO")
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.Area)
                .WithMany(p => p.Personal)
                .HasForeignKey(d => d.IdAre)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Cargo)
                .WithMany(p => p.Personal)
                .HasForeignKey(d => d.IdCar)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Empresa)
                .WithMany(p => p.Personal)
                .HasForeignKey(d => d.IdEmp)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
