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

        // Retorna os países e suas infecções:
        public IActionResult Index()
        {
            using (var db = new CovidContext())
            {
                var paises = db.Paises.ToList();
                ViewData["Paises"] = paises;

                return View();
            }
        }

        public string Pais()
        {
            using (var db = new CovidContext())
            {
                db.Add(
                    new Pais
                    {
                        Nome = "Brasil",
                    }
                );
                db.SaveChanges();

                // Read
                var paises = db.Paises.ToList();
                ViewData["Paises"] = paises;
            }
            return "ok";
        }

        // Teste para adicionar paises
        public IActionResult Teste()
        {
            using (var db = new CovidContext())
            {
                // Cria uma infeccao:
                var i = new Infeccao
                {
                    CasosConfirmados = 240000,
                    Mortes = 14000,
                    Recuperados = 2300,
                };
                i = db.Add(i).Entity;

                // Cria um pais:
                db.Add(
                    new Pais
                    {
                        Nome = "Brasil",
                        InfeccaoId = i.InfeccaoId,
                    }
                );
                db.SaveChanges();

                // Read
                var paises = db.Paises.ToList();
                ViewData["Paises"] = paises;

            }
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
