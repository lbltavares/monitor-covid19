using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace monitor_covid19.Models
{

    public class Pais
    {
        [Key]
        public int PaisId { get; set; }

        public string Nome { get; set; }

        // Chave estrangeira
        public int InfeccaoId { get; set; }

        // Navigation:
        public Infeccao Infeccao { get; set; } 
    }

}