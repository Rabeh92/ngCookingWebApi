using ngCookingWebApi.Models;
using ngCookingWebApi.Persistance.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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

        public void DeleteIngredient(int id)
        {

            _context.Ingredients.Remove(_context.Ingredients.Single(i => i.Id == id));
        }

        public IEnumerable<Ingredient> GetAlIngredient()
        {
            return _context.Ingredients.ToList();
        }

        public Ingredient GetIngredient(int id)
        {
            return _context.Ingredients.FirstOrDefault(i => i.Id == id);
        }

        public void UpdateUpdateIngredient(int id, Ingredient ingredient)
        {
            var ingredientInDb = _context.Ingredients.FirstOrDefault(i => i.Id == id);
            // set original entity state to detached
            _context.Entry(ingredientInDb).State = EntityState.Detached;

            // attach & save
            _context.Ingredients.Attach(ingredient);

            // set the updated entity state to modified, so it gets updated.
            _context.Entry(ingredient).State = EntityState.Modified;


        }
    }
}