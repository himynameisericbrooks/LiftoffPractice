using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LiftoffPractice.Models;

namespace LiftoffPractice.ViewModels
{
    public class EditMaterialViewModel
    {
        public int MaterialId { get; set; }
        public string TagText { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "Name must be 1-25 characters")]
        public string Name { get; set; }
        [StringLength(20, ErrorMessage = "The Artist/Composer must be 20 characters or less")]
        public string ArtistComposer { get; set; }

        [StringLength(20, ErrorMessage = "The key must be 20 characters or less")]
        public string KeyCenter { get; set; }

        [StringLength(15, ErrorMessage = "The tempo must be 15 characters or less")]
        public string Tempo { get; set; }

        [StringLength(15, ErrorMessage = "The time signature must be 15 characters or less")]
        public string TimeSig { get; set; }

        [StringLength(500, ErrorMessage = "Description must be 500 characters or less")]
        public string Description { get; set; }

        [Range(0, 10, ErrorMessage = "Mastery must be between 0 and 10")]
        public int Mastery { get; set; }


        public EditMaterialViewModel(Material theMaterial, List<MaterialTag> materialTags)
        {
            MaterialId = theMaterial.Id;
            Name = theMaterial.Name;
            ArtistComposer = theMaterial.ArtistComposer;
            KeyCenter = theMaterial.KeyCenter;
            Tempo = theMaterial.Tempo;
            TimeSig = theMaterial.TimeSig;
            Mastery = theMaterial.Mastery;
            Description = theMaterial.Description;

            TagText = "";

            for (var i = 0; i < materialTags.Count; i++)
            {
                TagText += "#" + materialTags[i].Tag.Name;

                if (i < materialTags.Count - 1)
                {
                    TagText += ", ";
                }
            }
        }

        //public EditMaterialTagViewModel()
        //{
        //}
    }
}
