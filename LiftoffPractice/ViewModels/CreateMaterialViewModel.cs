using System;
using System.ComponentModel.DataAnnotations;

namespace LiftoffPractice.ViewModels
{
    public class CreateMaterialViewModel
    {
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

        [Range(0,10, ErrorMessage = "Mastery must be between 0 and 10")]
        public int Mastery { get; set; }
    }
}
