using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using ngCookingWebApi.Models;

namespace ngCookingWebApi.Persistance.EntityConfigurations
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            //table configuration
            ToTable("Comments");

            //primary key configuration
            HasKey(c => c.Id);

            
        }
    }
}