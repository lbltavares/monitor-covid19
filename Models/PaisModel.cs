using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace monitor_covid19.Models
{
  public class PaisModel
  {
    [Key]
    public int PaisId { get; set; }
    public string Nome { get; set; }
    public InfeccaoModel Infeccao { get; set; }
  }
}
