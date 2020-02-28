using ngCookingWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngCookingWebApi.Persistance.Repositories.Abstract
{
    public interface IRecetteRepository
    {
        IEnumerable<Recette> GetAllRecette();
        Recette GetRecette(int id);
        void AddNewRecette(Recette recette);
        void UpdateRecette(Recette recetteInDb, Recette recette);
        void DeleteRecette(Recette recette);
    }
}
