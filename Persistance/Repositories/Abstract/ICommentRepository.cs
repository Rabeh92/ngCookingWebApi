using ngCookingWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngCookingWebApi.Persistance.Repositories.Abstract
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetCommentByRecette(int idRecette);
        void AddCommentToRecette(Comment comment);
        double GetMarkByRecette(int idRecette);
    }
}
