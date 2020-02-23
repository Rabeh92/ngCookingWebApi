using ngCookingWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Persistance.EntityConfigurations
{
    public class CategorieIngredientConfiguration : EntityTypeConfiguration<CategorieIngredient>
    {
        public CategorieIngredientConfiguration()
        {
            //primary key
            HasKey(ci => ci.Id);

            //table name
            ToTable("CategorieIngredients");

            //Configure properties
            Property(ci => ci.NameToDisplay)
                .IsRequired()
                .HasMaxLength(255);

            //Configure relations
            HasMany(ci => ci.Ingredients)
                .WithRequired(i => i.Categorie)
                .HasForeignKey(i => i.CategorieId)
                .WillCascadeOnDelete(true);
        }
    }
}