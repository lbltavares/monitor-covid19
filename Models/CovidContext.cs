using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace monitor_covid19.Models
{
    public class CovidContext : DbContext
    {

        public DbSet<Infeccao> Infeccoes { get; set; }

        public DbSet<Pais> Paises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=covid19.db");
    }
}