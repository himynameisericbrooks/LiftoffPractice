using System;
using System.ComponentModel.DataAnnotations;

namespace LiftoffPractice.Models
{
    public class Tag
    {
        //public string UserId { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 30 characters")]
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
