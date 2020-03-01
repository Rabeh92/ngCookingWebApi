using ngCookingWebApi.Persistance.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using ngCookingWebApi.Persistance.Repositories.Concrete;
namespace ngCookingWebApi.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        [Dependency]
        public IIngredientRepository Ingredients { get; set; }

        [Dependency]
        public IRecetteRepository Recettes { get; set; }

        [Dependency]
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