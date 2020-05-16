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
    public IActionResult Index(string firstName)
    {
      return Content($"Hello {firstName}");
    }

    // [Route("Admin")]
    // [Route("Admin/{id?}")]
    public IActionResult Admin(String? id)
    {
      if (id == "5ebdd59791a6460d10833a00")
      {
        Console.WriteLine("Loggado");
      }
      else
      {
        Console.WriteLine("FILHO DA PULTA");
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
