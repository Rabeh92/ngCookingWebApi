using Microsoft.AspNet.Identity.EntityFramework;
using ngCookingWebApi.Models;
using ngCookingWebApi.Persistance.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<CategorieIngredient> CategorieIngredients { get; set; }
        public DbSet<CategorieRecette> CategorieRecettes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recette> Recettes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategorieIngredientConfiguration());
            modelBuilder.Configurations.Add(new CategorieRecetteConfiguration());
            modelBuilder.Configurations.Add(new IngredientConfiguration());
            modelBuilder.Configurations.Add(new RecetteConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}