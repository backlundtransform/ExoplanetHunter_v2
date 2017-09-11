
using Microsoft.EntityFrameworkCore;

using MySQL.Data.EntityFrameworkCore.Extensions;
using System.Configuration;

namespace ExoplanetService.Models
{
    public class ExoContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {




         
            optionbuilder.UseMySQL(ConfigurationManager.ConnectionStrings["ExoConnectionString"].ConnectionString);
        }

        public DbSet<Star> Stars { get; set; }
        public DbSet<Planet> Planets { get; set; }

        public DbSet<Constellation> Constellations { get; set; }
    }
}
