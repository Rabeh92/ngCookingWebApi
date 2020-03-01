using ngCookingWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int Mark { get; set; }

        public Recette Recette { get; set; }
        public int RecetteId { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}