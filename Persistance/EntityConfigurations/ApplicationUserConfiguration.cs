using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using ngCookingWebApi.Models;

namespace ngCookingWebApi.Persistance.EntityConfigurations
{
    public class ApplicationUserConfiguration:EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            //relations configuration
            HasMany(u => u.Recettes)
                .WithRequired(r => r.User)
                .HasForeignKey(r => r.UserId);

            HasMany(u => u.Comments)
                .WithRequired(c => c.User)
                .HasForeignKey(c => c.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}