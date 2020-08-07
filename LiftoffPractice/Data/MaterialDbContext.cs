using System;
using LiftoffPractice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LiftoffPractice.Data
{
    public class MaterialDbContext : IdentityDbContext<IdentityUser>
        {
            public DbSet<Material> Materials { get; set; }
            public DbSet<Tag> Tags { get; set; }
            public DbSet<MaterialTag> MaterialTags { get; set; }

        public MaterialDbContext(DbContextOptions<MaterialDbContext> options) : base(options)
            {
            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaterialTag>().HasKey(et => new { et.MaterialId, et.TagId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
