using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }


        public DbSet<Medico> Medico { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<UnidadeSaude> UnidadeSaude { get; set; }
        public DbSet<BuscaEspecialidade> BuscaEspecialidade { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Plantao> Plantaos { get; set; }


        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("criado") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity.GetType().GetProperty("criado") != null)
                    {
                        if (entry.Property("criado").CurrentValue == null)
                            entry.Property("criado").CurrentValue = DateTime.Now;
                    }


                    if (entry.Entity.GetType().GetProperty("editado") != null)
                        entry.Property("editado").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity.GetType().GetProperty("criado") != null)
                        entry.Property("criado").IsModified = false;

                    if (entry.Entity.GetType().GetProperty("editado") != null)
                        entry.Property("editado").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }


    }
}
