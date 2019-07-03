using Microsoft.EntityFrameworkCore;
using NisiulInfoSoft.DTO;
using NisiulInfoSoft.DTOMapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace NisiulInfoSoft.Context
{
    public class NisiulInfoSoftContext : DbContext
    {
        public NisiulInfoSoftContext(DbContextOptions dbContextOptions) : 
            base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AreaDTOMapping());
            modelBuilder.ApplyConfiguration(new CargoDTOMapping());
            modelBuilder.ApplyConfiguration(new EmpresaDTOMapping());
            modelBuilder.ApplyConfiguration(new PersonalDTOMapping());
            modelBuilder.ApplyConfiguration(new TipoUsuarioDTOMapping());
            modelBuilder.ApplyConfiguration(new UsuarioDTOMapping());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AreaDTO> Area { get; set; }
        public DbSet<CargoDTO> Cargo { get; set; }
        public DbSet<EmpresaDTO> Empresa { get; set; }
        public DbSet<PersonalDTO> Personal { get; set; }
        public DbSet<TipoUsuarioDTO> TipoUsuario { get; set; }
        public DbSet<UsuarioDTO> Usuario { get; set; }
    }
}
