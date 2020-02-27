using ngCookingWebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Dtos
{
    public class IngredientDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public string Picture { get; set; }
        public CategorieIngredient Categorie { get; set; }

        [Required]
        public int CategorieId { get; set; }

        public int Calorie { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
    }
}