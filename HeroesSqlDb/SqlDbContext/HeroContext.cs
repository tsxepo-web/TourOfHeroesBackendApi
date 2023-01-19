using HeroesSqlDb.Entity;
using Microsoft.EntityFrameworkCore;


namespace HeroesSqlDb.SqlDbContext
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options)
            : base(options)
        {
        }
        public DbSet<Hero> Heroes { get; set; } = null!;
    }
}
