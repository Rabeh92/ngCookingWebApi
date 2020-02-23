
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using ngCookingWebApi.Models;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ngCookingWebApi.Persistance.EntityConfigurations
{
    public class IngredientConfiguration:EntityTypeConfiguration<Ingredient>
    {
        public IngredientConfiguration()
        {
            //Table configuration
            ToTable("Ingredients");

            //Primary key
            HasKey(i => i.Id);

            //Properties configuration
            Property(i => i.Description).HasMaxLength(300);
            Property(i=>i.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnAnnotation("Index", 
                new IndexAnnotation(new IndexAttribute("IngredientNameIndex") { IsUnique = true }));

            //Relations configuration
            
        }
    }
}