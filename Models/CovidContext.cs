using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace monitor_covid19.Models
{
  public class CovidContext : DbContext
  {

    public DbSet<InfeccaoModel> Infeccoes { get; set; }

    public DbSet<PaisModel> Paises { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<PaisModel>()
          .HasOne(a => a.Infeccao)
          .WithOne(b => b.Pais)
          .HasForeignKey<InfeccaoModel>(b => b.PaisRef);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=covid19.db");


  }

}
