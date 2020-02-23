using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using ngCookingWebApi.Models;

namespace ngCookingWebApi.Persistance.EntityConfigurations
{
    public class CategorieRecetteConfiguration:EntityTypeConfiguration<CategorieRecette>
    {
        public CategorieRecetteConfiguration()
        {
            //table name
            ToTable("CategorieRecettes");

            //primary key
            HasKey(cr=>cr.Id);

            //Configure properies
            Property(cr => cr.NameToDisplay)
                .IsRequired()
                .HasMaxLength(255);

            //Configure relations
            HasMany(cr => cr.Recettes)
                .WithRequired(r => r.Categorie)
                .HasForeignKey(r => r.CategorieId);
        }


    }
}