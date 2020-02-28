using ngCookingWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Dtos
{
    public class RecetteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long CreationDate { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public bool IsAvailable { get; set; }
        public CategorieRecette Categorie { get; set; }
        public int CategorieId { get; set; }
        public string Picture { get; set; }
        public int Calorie { get; set; }
        //public ICollection<Ingredient> Ingredients { get; set; }
        public string Preparation { get; set; }
        //public ICollection<Comment> Comments { get; set; }
    }
}