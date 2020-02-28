using ngCookingWebApi.Models;
using ngCookingWebApi.Persistance.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Persistance.Repositories.Concrete
{
    public class RecetteRepository : IRecetteRepository
    {
        private readonly ApplicationDbContext _context;
        public RecetteRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddNewRecette(Recette recette)
        {
            _context.Recettes.Add(recette);
        }

        public void DeleteRecette(Recette recette)
        {

            _context.Recettes.Remove(recette);
        }

        public IEnumerable<Recette> GetAllRecette()
        {
           return _context.Recettes.ToList();
        }

        public Recette GetRecette(int id)
        {
            return _context.Recettes.FirstOrDefault(r => r.Id == id);
        }

        public void UpdateRecette(Recette recetteInDb, Recette recette)
        {
            _context.Entry(recetteInDb).State = EntityState.Detached;
            _context.Recettes.Attach(recette);
            _context.Entry(recette).State = EntityState.Modified;
        }
    }
}