using ngCookingWebApi.Models;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
namespace ngCookingWebApi.Persistance.EntityConfigurations
{
    public class RecetteConfiguration : EntityTypeConfiguration<Recette>
    {
        public RecetteConfiguration()
        {
            //Table configuration
            ToTable("Recettes");

            //Primary Key
            HasKey(r => r.Id);

            //properties configuration
            Property(r => r.Name).IsRequired().HasMaxLength(255)
                .HasColumnAnnotation("Index",
                new IndexAnnotation(new IndexAttribute("NameIndex") { IsUnique = true }));

            //Relatioons configuration
            HasMany(r => r.Ingredients)
                .WithMany(i => i.Recettes)
                .Map(ri =>
                {
                    ri.MapLeftKey("IngredientId");
                    ri.MapRightKey("RecetteId");
                    ri.ToTable("Recette_Ingredients");
                });

            HasMany(r => r.Comments)
                .WithRequired(c => c.Recette)
                .HasForeignKey(c => c.RecetteId);
        }
    }
}