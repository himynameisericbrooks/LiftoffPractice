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
using Microsoft.EntityFrameworkCore;

namespace LiftoffPractice.Controllers
{
    public class HomeController : Controller
    {
        private MaterialDbContext context;

        public HomeController(MaterialDbContext dbContext)
        {
            context = dbContext;
        }



        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        // GET: /controller/
        [HttpGet]
        public IActionResult Index()
        {
            List<Material> materials = context.Materials.ToList();
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
            if (ModelState.IsValid)
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
                context.Materials.Add(newMaterial);
                context.SaveChanges();

                return Redirect("/Home");
            }

            return View(createMaterialViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.materials = context.Materials.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] materialIds)
        {
            foreach (int materialId in materialIds)
            {
                Material theMaterial = context.Materials.Find(materialId);
                context.Materials.Remove(theMaterial);
            }

            context.SaveChanges();

            return Redirect("/Home");
        }

        public IActionResult Detail(int id)
        {
            Material theMaterial = context.Materials
                .Single(m => m.Id == id);

            List<MaterialTag> materialTags = context.MaterialTags
                .Where(mt => mt.MaterialId == id)
                .Include(mt => mt.Tag)
                .ToList();

            MaterialDetailViewModel viewModel = new MaterialDetailViewModel(theMaterial, materialTags);
            return View(viewModel);
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
