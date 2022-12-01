using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesDB.Entity;
using Microsoft.EntityFrameworkCore;


namespace HeroesDB.Sqldb
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
