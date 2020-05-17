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
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Remover(string infeccaoId)
        {
            using (var db = new CovidContext())
            {
                db.Infeccoes.Remove(db.Infeccoes.Where(i => i.InfeccaoId == int.Parse(infeccaoId)).First());

                db.SaveChanges();

                var infeccoes = db.Infeccoes.ToList();
                db.Paises.ToList();

                ViewData["Infeccoes"] = infeccoes;
                return View("Painel");
            }
        }

        private string Senha = "abc123";


        [HttpPost]
        public IActionResult Criar(string pais, string casos, string mortes, string recuperados)
        {

            using (var db = new CovidContext())
            {
                // Se existir o país:
                if (db.Infeccoes.Where(infeccao => infeccao.Pais.Nome == pais).Any())
                {
                    var inf = db.Infeccoes.Where(infeccao => infeccao.Pais.Nome == pais).First();
                    inf.CasosConfirmados = int.Parse(casos);
                    inf.Mortes = int.Parse(mortes);
                    inf.Recuperados = int.Parse(recuperados);
                    db.Update(inf);
                }
                else
                {
                    var novopais = new PaisModel();
                    novopais.Nome = pais;
                    var novainfection = new InfeccaoModel();
                    novainfection.CasosConfirmados = int.Parse(casos);
                    novainfection.Mortes = int.Parse(mortes);
                    novainfection.Recuperados = int.Parse(recuperados);

                    novopais.Infeccao = novainfection;
                    db.Infeccoes.Add(novainfection);
                    db.Paises.Add(novopais);

                }
                db.SaveChanges();

                var infeccoes = db.Infeccoes.ToList();
                db.Paises.ToList();
                ViewData["Infeccoes"] = infeccoes;
                return View("Painel");
            }
        }


        [HttpPost]
        public IActionResult Index(string senha)
        {
            if (senha == Senha)
            {
                using (var db = new CovidContext())
                {
                    var infeccoes = db.Infeccoes.ToList();
                    db.Paises.ToList();

                    ViewData["Infeccoes"] = infeccoes;

                    return View("Painel");
                }
            }
            else
            {
                ViewData["SenhaInvalida"] = true;
                return View();
            }
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
