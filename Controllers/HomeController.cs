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
        // var novopais = new PaisModel();
        // novopais.Nome = "Brasil";
        // var novainfection = new InfeccaoModel();
        // novainfection.CasosConfirmados = 10;
        // novainfection.Mortes = 10;
        // novainfection.Recuperados = 100;

        // novopais.Infeccao = novainfection;
        // db.Infeccoes.Add(novainfection);
        // db.Paises.Add(novopais);
        // db.SaveChanges();


        var employee = db.Paises
            .OrderBy(b => b.PaisId)
            .Where(p => p.Nome == "Brasil")
            .ToList();

        var employeee = db.Infeccoes
                    .ToList();

        foreach (var item in employee)
        {
          Console.WriteLine(item.PaisId);
          Console.WriteLine(item.Nome);
          Console.WriteLine(item.Infeccao.Recuperados);
        }
        private string Senha = "abc123";

    [HttpPost]
    public IActionResult Admin3(string senha)
    {
      Console.WriteLine("Senha: " + senha);
      if (senha == Senha)
        return Content($"Senha correta: {senha}");
      else
      {
        ViewData["SenhaInvalida"] = true;
        return View();
      }
    }

    [HttpGet]
    public IActionResult Admin2()
    {
      using (var db = new CovidContext())
      {
        // Create
        // var novopais = new PaisModel();
        // novopais.Nome = "Brasil";
        // var novainfection = new InfeccaoModel();
        // novainfection.CasosConfirmados = 10;
        // novainfection.Mortes = 10;
        // novainfection.Recuperados = 100;

        // novopais.Infeccao = novainfection;
        // db.Infeccoes.Add(novainfection);
        // db.Paises.Add(novopais);
        // db.SaveChanges();

        // var a = db.Query<Val>("").First();

        var inf = db.Infeccoes
                    .OrderBy(b => b.InfeccaoId)
                    .First();
        Console.WriteLine("Pais: " + inf.Pais);

      }
      return View();
    }

    [Route("About")]
    [Route("About/{id?}")]
    public IActionResult About(int? id)
    {
      Console.WriteLine(id);
      Console.WriteLine("OIIIIIIIIOIIIIIIIIOIIIIIIIIOIIIIIIIIOIIIIIIIIOIIIIIIIIOIIIIIIIIOIIIIIIIIOIIIIIIII");

      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
