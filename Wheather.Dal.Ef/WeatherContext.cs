using Microsoft.EntityFrameworkCore;
using System;
using Wheather.Dal.Entities;

namespace Wheather.Dal.Ef
{
    public class WeatherContext : DbContext
    {
        public DbSet<Favorite> Favorites { get; set; }

        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
