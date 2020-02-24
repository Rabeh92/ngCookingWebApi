using ngCookingWebApi.Persistance.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IIngredientRepository Ingredients { get; set; }
        public IRecetteRepository Recettes { get; set; }
        public ICommentRepository Comments { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}