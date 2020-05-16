using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using monitor_covid19.Models;

namespace monitor_covid19.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }


    public IActionResult Admin()
    {
      using (var db = new CovidContext())
      {
        // Create
        Console.WriteLine("Add New Employee: ");
        var novopais = new PaisModel();
        novopais.Nome = "Brasil";
        var novainfection = new InfeccaoModel();
        novainfection.CasosConfirmados = 10;
        novainfection.Mortes = 10;
        novainfection.Recuperados = 100;

        novopais.Infeccao = novainfection;
        db.Infeccoes.Add(novainfection);
        db.Paises.Add(novopais);
        db.SaveChanges();

        // var a = db.Query<Val>("").First();

        var employee = db.Paises
            .OrderBy(b => b.PaisId)
            .First();

        var employeee = db.Infeccoes
                    .OrderBy(b => b.InfeccaoId)
                    .First();
        Console.WriteLine(employeee.Pais.Nome);

      }
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
