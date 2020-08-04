using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LiftoffPractice.Models;

namespace LiftoffPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        static private List<Material> Materials = new List<Material>();

        // GET: /controller/
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.materials = Materials;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/Home/Create")]
        public IActionResult NewMaterial(string name, string artistComposer, string keyCenter, string tempo, string timeSig, string description, int mastery)
        {
            Materials.Add(new Material(name, artistComposer, keyCenter, tempo, timeSig, description, mastery));

            return Redirect("/Home");
        }




        public IActionResult Privacy()
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
