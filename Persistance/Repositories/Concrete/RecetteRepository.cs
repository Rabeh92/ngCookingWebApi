using ngCookingWebApi.Models;
using ngCookingWebApi.Persistance.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Persistance.Repositories.Concrete
{
    public class RecetteRepository : IRecetteRepository
    {
        public void AddNewRecette(Recette recette)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecette(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recette> GetAllRecette()
        {
            throw new NotImplementedException();
        }

        public Recette GetRecette(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecette(Recette recette, int id)
        {
            throw new NotImplementedException();
        }
    }
}