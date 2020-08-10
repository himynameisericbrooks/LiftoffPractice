using System;
using System.ComponentModel.DataAnnotations;

namespace LiftoffPractice.Models
{
    public class Tag
    {
        //public string UserId { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        public Tag(string name)
        {
            Name = name;
        }

        public Tag()
        {
        }
    }
}
