using ngCookingWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngCookingWebApi.Persistance.Repositories.Abstract
{
    interface IIngredientRepository
    {
        IEnumerable<Ingredient> GetAlIngredient();
        Ingredient GetIngredient(int id);
        void AddNewIngredient(Ingredient ingredient);
        void UpdateUpdateIngredient(int id,Ingredient ingredient);
        void DeleteIngredient(int id);
    }
}
