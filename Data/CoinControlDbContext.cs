using Microsoft.EntityFrameworkCore;
using CoinControl.Api.Models;
using CoinControl.Api.Data.Seed;


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

            modelBuilder.SeedCategorias();
        }

    }
}