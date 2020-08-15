using System;
using System.Collections.Generic;
using LiftoffPractice.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LiftoffPractice.ViewModels
{
    public class AddMaterialTagViewModel
    {
        public string UserId { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public List<SelectListItem> Tags { get; set; }

        public int TagId { get; set; }

        public AddMaterialTagViewModel(Material theMaterial, List<Tag> possibleTags)
        {
            Tags = new List<SelectListItem>();

            foreach (var tag in possibleTags)
            {
                Tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.Name
                });
            }

            Material = theMaterial;
        }


        public AddMaterialTagViewModel()
        {
        }
    }
}
