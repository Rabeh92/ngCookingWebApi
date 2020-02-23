using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            Recettes = new Collection<Recette>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public string Picture { get; set; }
        public CategorieIngredient Categorie { get; set; }

        public int CategorieId { get; set; }

        public int Calorie { get; set; }

        public string Description { get; set; }
        public ICollection<Recette> Recettes { get; set; }
    }
}