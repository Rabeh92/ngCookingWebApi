using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Models
{
    public class CategorieRecette
    {
        public CategorieRecette()
        {
            Recettes = new Collection<Recette>();
        }
        public int Id { get; set; }
        public string NameToDisplay { get; set; }
        public ICollection<Recette> Recettes { get; set; }
    }
}