using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }

        public Recette Recette { get; set; }
        public int RecetteId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}