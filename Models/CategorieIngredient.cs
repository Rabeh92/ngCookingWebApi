using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Models
{
    public class CategorieIngredient
    {
        public CategorieIngredient()
        {
            Ingredients = new Collection<Ingredient>();
        }
        public int Id { get; set; }
        public string NameToDisplay { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}