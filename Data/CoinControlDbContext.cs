using Microsoft.EntityFrameworkCore;
using CoinControl.Api.Models;

namespace CoinControl.Api.Data
{
    public class CoinControlDbContext : DbContext
    {
        public CoinControlDbContext(DbContextOptions<CoinControlDbContext> options)
            : base(options)
        { }

        public DbSet<UserModel> Users { get; set; }

    }
}