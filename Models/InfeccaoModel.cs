using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace monitor_covid19.Models
{
    public class CovidContext : DbContext
    {

        public DbSet<InfeccaoModel> Infeccoes { get; set; }

        public DbSet<PaisModel> Paises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=covid19.db");
    }

    public class InfeccaoModel
    {
        [Key]
        public int InfeccaoId { get; set; }

        public int CasosConfirmados { get; set; }

        public int Mortes { get; set; }

        public int Recuperados { get; set; }

    }

    public class PaisModel
    {
        [Key]
        public int PaisId { get; set; }
        public string Nome { get; set; }
        public InfeccaoModel infeccao { get; set; }
    }
}