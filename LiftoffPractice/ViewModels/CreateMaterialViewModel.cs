using System;
namespace LiftoffPractice.ViewModels
{
    public class CreateMaterialViewModel
    {
        public string Name { get; set; }
        public string ArtistComposer { get; set; }
        public string KeyCenter { get; set; }
        public string Tempo { get; set; }
        public string TimeSig { get; set; }
        public string Description { get; set; }
        public int Mastery { get; set; }
    }
}
