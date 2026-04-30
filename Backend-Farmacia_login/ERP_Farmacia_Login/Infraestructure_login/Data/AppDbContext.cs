using Domian_login.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure_login.Data
{
    using Domian_login.entities;
    using Microsoft.EntityFrameworkCore;
    using System;

    namespace Infraestructure_login.Data
    {
        public class AppDbContext : DbContext
        {
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Auditoria> Auditorias { get; set; }
            public DbSet<Rol> Roles { get; set; }

            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

            // 👇 AQUÍ VA
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder); // buena práctica
                    
                modelBuilder.Entity<Usuario>()
                    .HasOne(u => u.Rol)
                    .WithMany(r => r.Usuarios)
                    .HasForeignKey(u => u.RolId);

                modelBuilder.Entity<Auditoria>()
                    .HasOne(a => a.Usuario)
                    .WithMany(u => u.Auditorias)
                    .HasForeignKey(a => a.UsuarioId);
            }
        }
    }

}
