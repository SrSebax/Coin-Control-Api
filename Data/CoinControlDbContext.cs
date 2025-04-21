using Microsoft.EntityFrameworkCore;
using CoinControl.Api.Models;

namespace CoinControl.Api.Data
{
    public class CoinControlDbContext : DbContext
    {
        public CoinControlDbContext(DbContextOptions<CoinControlDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación entre Categoria y User usando Uid
            modelBuilder.Entity<Categoria>()
                .HasOne(c => c.User)
                .WithMany()  // Un Usuario puede tener muchas Categorías
                .HasForeignKey(c => c.Uid) // Establecemos que la clave foránea es Uid
                .HasPrincipalKey(u => u.Uid); // Especificamos que Uid es la clave principal en User
        }
    }
}
