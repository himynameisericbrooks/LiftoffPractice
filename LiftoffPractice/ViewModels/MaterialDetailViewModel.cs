using System;
using System.Collections.Generic;
using LiftoffPractice.Models;

namespace LiftoffPractice.ViewModels
{
    public class MaterialDetailViewModel
    {
        public int MaterialId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ArtistComposer { get; set; }
        public string KeyCenter { get; set; }
        public string Tempo { get; set; }
        public string TimeSig { get; set; }
        public int Mastery { get; set; }
        public string TagText { get; set; }


        public MaterialDetailViewModel(Material theMaterial, List<MaterialTag> materialTags)
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
    }
}
