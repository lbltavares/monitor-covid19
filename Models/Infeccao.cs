using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace monitor_covid19.Models
{

    public class Infeccao
    {
        [Key]
        public int InfeccaoId { get; set; }

        public int CasosConfirmados { get; set; }

        public int Mortes { get; set; }

        public int Recuperados { get; set; }

    }
}