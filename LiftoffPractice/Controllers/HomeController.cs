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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LiftoffPractice.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private MaterialDbContext context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(MaterialDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }



        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        // GET: /controller/
        [HttpGet, HttpPost]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            ViewBag.materials = context.Materials
                .Where(m => m.UserId == userId)
                .ToList();
            return View();
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
                var userId = _userManager.GetUserId(User);

                Material newMaterial = new Material
                {
                    Name = createMaterialViewModel.Name,
                    ArtistComposer = createMaterialViewModel.ArtistComposer,
                    KeyCenter = createMaterialViewModel.KeyCenter,
                    Tempo = createMaterialViewModel.Tempo,
                    TimeSig = createMaterialViewModel.TimeSig,
                    Description = createMaterialViewModel.Description,
                    Mastery = createMaterialViewModel.Mastery,
                    UserId = userId
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Material theMaterial = context.Materials
                .Single(m => m.Id == id);

            List<MaterialTag> materialTags = context.MaterialTags
                .Where(mt => mt.MaterialId == id)
                .Include(mt => mt.Tag)
                .ToList();

            EditMaterialViewModel viewModel = new EditMaterialViewModel(theMaterial, materialTags);
            return View(viewModel);
        }

        //[HttpPost]
        //public IActionResult Edit(EditMaterialViewModel editMaterialViewModel)
        //{
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            Material updateMaterial = new Material
        //            {
        //                Name = editMaterialViewModel.Name,
        //                ArtistComposer = editMaterialViewModel.ArtistComposer,
        //                KeyCenter = editMaterialViewModel.KeyCenter,
        //                Tempo = editMaterialViewModel.Tempo,
        //                TimeSig = editMaterialViewModel.TimeSig,
        //                Description = editMaterialViewModel.Description,
        //                Mastery = editMaterialViewModel.Mastery
        //            };
        //            context.Materials.Update(updateMaterial);
        //            context.SaveChanges();

        //            return Redirect("/Home");
        //        }

        //        return View(editMaterialViewModel);
        //    }
        //}

        [HttpPost]
        public IActionResult EditPost(EditMaterialViewModel editMaterialViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                Material theMaterial = context.Materials.Find(id);
                //.Set(tm => tm.Name = editMaterialViewModel.Name);
                ////.Where(mt => mt.MaterialId == id)
                ////.Set(theMaterial.Name = editMaterialViewModel.Name);
                theMaterial.Name = editMaterialViewModel.Name;


                context.Materials.Update(theMaterial);
                context.SaveChanges();

                return Redirect("/Home");
            }

            return View();
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
