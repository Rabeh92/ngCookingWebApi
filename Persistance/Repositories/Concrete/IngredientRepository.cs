using ngCookingWebApi.Models;
using ngCookingWebApi.Persistance.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;

namespace ngCookingWebApi.Persistance.Repositories.Concrete
{
    public class IngredientRepository : IIngredientRepository
    {

        private readonly ApplicationDbContext _context;
        public IngredientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddNewIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);

        }

        public void DeleteIngredient(Ingredient ingredient)
        {

            _context.Ingredients.Remove(ingredient);
        }

        public IEnumerable<Ingredient> GetAlIngredient()
        {
            try
            {
                return _context.Ingredients.Include(i => i.Categorie).ToList();
            }
            catch (Exception)
            {

                return null;
            }

        }

        public Ingredient GetIngredient(int id)
        {
            return _context.Ingredients.Include(i => i.Categorie).FirstOrDefault(i => i.Id == id);
        }

        public void UpdateIngredient(Ingredient ingredientInDb, Ingredient ingredient)
        {
            // set original entity state to detached
            _context.Entry(ingredientInDb).State = EntityState.Detached;

            // attach & save
            _context.Ingredients.Attach(ingredient);

            // set the updated entity state to modified, so it gets updated.
            _context.Entry(ingredient).State = EntityState.Modified;


        }
    }
}