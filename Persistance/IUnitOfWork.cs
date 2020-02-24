using ngCookingWebApi.Persistance.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngCookingWebApi.Persistance
{
    public interface IUnitOfWork
    {
        IIngredientRepository Ingredients { get; set; }
        IRecetteRepository Recettes { get; set; }
        ICommentRepository Comments { get; set; }
        void Complete();
        void Dispose();
    }
}
