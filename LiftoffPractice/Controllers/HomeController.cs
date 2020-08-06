using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LiftoffPractice.Models;
using LiftoffPractice.Data;
using LiftoffPractice.ViewModels;

namespace LiftoffPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }




        // GET: /controller/
        [HttpGet]
        public IActionResult Index()
        {
            List<Material> materials = new List<Material>(MaterialData.GetAll());
            return View(materials);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateMaterialViewModel createMaterialViewModel = new CreateMaterialViewModel();
            return View(createMaterialViewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateMaterialViewModel createMaterialViewModel)
        {
            Material newMaterial = new Material
            {
                Name = createMaterialViewModel.Name,
                ArtistComposer = createMaterialViewModel.ArtistComposer,
                KeyCenter = createMaterialViewModel.KeyCenter,
                Tempo = createMaterialViewModel.Tempo,
                TimeSig = createMaterialViewModel.TimeSig,
                Description = createMaterialViewModel.Description,
                Mastery = createMaterialViewModel.Mastery
            };
            MaterialData.Add(newMaterial);

            return Redirect("/Home");
        }

        public IActionResult Delete()
        {
            ViewBag.materials = MaterialData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] materialIds)
        {
            foreach (int materialId in materialIds)
            {
                MaterialData.Remove(materialId);
            }

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
