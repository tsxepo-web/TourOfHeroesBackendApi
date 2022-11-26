using Microsoft.EntityFrameworkCore;

namespace HeroDB.Entity
{
    public class HeroContext: DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options)
            : base(options)
        {
        }
        public DbSet<Hero> Heroes { get; set; } = null!;
    }
}
