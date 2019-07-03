using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NisiulInfosoft.EF.CodeFirst.Entities
{
    public partial class NisiulInfosoftContext : DbContext
    {
        public NisiulInfosoftContext()
        {
        }

        public NisiulInfosoftContext(DbContextOptions<NisiulInfosoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NisArea> NisArea { get; set; }
        public virtual DbSet<NisCargo> NisCargo { get; set; }
        public virtual DbSet<NisEmpresa> NisEmpresa { get; set; }
        public virtual DbSet<NisPersonal> NisPersonal { get; set; }
        public virtual DbSet<NisTipoUsuario> NisTipoUsuario { get; set; }
        public virtual DbSet<NisUsuario> NisUsuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=NISIULINFOSOFT;User ID=lmaza;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<NisArea>(entity =>
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
            });

            modelBuilder.Entity<NisCargo>(entity =>
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
            });

            modelBuilder.Entity<NisEmpresa>(entity =>
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
            });

            modelBuilder.Entity<NisPersonal>(entity =>
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

                entity.HasOne(d => d.IdAreNavigation)
                    .WithMany(p => p.NisPersonal)
                    .HasForeignKey(d => d.IdAre)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdCarNavigation)
                    .WithMany(p => p.NisPersonal)
                    .HasForeignKey(d => d.IdCar)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdEmpNavigation)
                    .WithMany(p => p.NisPersonal)
                    .HasForeignKey(d => d.IdEmp)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<NisTipoUsuario>(entity =>
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
            });

            modelBuilder.Entity<NisUsuario>(entity =>
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

                entity.HasOne(d => d.IdPerNavigation)
                    .WithMany(p => p.NisUsuario)
                    .HasForeignKey(d => d.IdPer)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdTipNavigation)
                    .WithMany(p => p.NisUsuario)
                    .HasForeignKey(d => d.IdTip)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}