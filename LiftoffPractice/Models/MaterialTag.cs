using System;
namespace LiftoffPractice.Models
{
    public class MaterialTag
    {
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }


        public MaterialTag()
        {
        }
    }
}
