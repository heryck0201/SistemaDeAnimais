using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaDeAnimais.Entidades;
using SistemaDeAnimais.Map;

namespace SistemaDeAnimais.Data
{
    public class SistemaDeAnimaisContext : IdentityDbContext
    {
        public SistemaDeAnimaisContext(DbContextOptions<SistemaDeAnimaisContext> options)
              :base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PetMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
