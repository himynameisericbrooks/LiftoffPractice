using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftoffPractice.Data;
using LiftoffPractice.Models;
using LiftoffPractice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiftoffPractice.Controllers
{
    public class TagController : Controller
    {
        private MaterialDbContext context;

        public TagController(MaterialDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Tag> tags = context.Tags.ToList();
            return View(tags);
        }

        public IActionResult Add()
        {
            Tag tag = new Tag();
            return View(tag);
        }

        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            if (ModelState.IsValid)
            {
                context.Tags.Add(tag);
                context.SaveChanges();
                return Redirect("/Tag/");
            }

            return View("Add", tag);
        }

        public IActionResult AddMaterial(int id)
        {
            Material theMaterial = context.Materials.Find(id);
            List<Tag> possibleTags = context.Tags.ToList();

            AddMaterialTagViewModel viewModel = new AddMaterialTagViewModel(theMaterial, possibleTags);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddMaterial(AddMaterialTagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int materialId = viewModel.MaterialId;
                int tagId = viewModel.TagId;

                List<MaterialTag> existingItems = context.MaterialTags
                    .Where(mt => mt.MaterialId == materialId)
                    .Where(mt => mt.TagId == tagId)
                    .ToList();

                if (existingItems.Count == 0)
                {

                    MaterialTag materialTag = new MaterialTag
                    {
                        MaterialId = materialId,
                        TagId = tagId
                    };

                    context.MaterialTags.Add(materialTag);
                    context.SaveChanges();
                }

                return Redirect("/Home/Detail/" + materialId);
            }

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            List<MaterialTag> materialTags = context.MaterialTags
                .Where(mt => mt.TagId == id)
                .Include(mt => mt.Material)
                .Include(MaterialTag => MaterialTag.Tag)
                .ToList();

            return View(materialTags);
        }
    }
}
