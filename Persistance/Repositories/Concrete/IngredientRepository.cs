using ngCookingWebApi.Models;
using ngCookingWebApi.Persistance.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Persistance.Repositories.Concrete
{
    public class IngredientRepository : IIngredientRepository
    {
        public void AddNewIngredient(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public void DeleteIngredient(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> GetAlIngredient()
        {
            throw new NotImplementedException();
        }

        public Ingredient GetIngredient(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUpdateIngredient(int id, Ingredient ingredient)
        {
            throw new NotImplementedException();
        }
    }
}