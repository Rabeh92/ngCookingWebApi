using ngCookingWebApi.Models;
using ngCookingWebApi.Persistance.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ngCookingWebApi.Persistance.Repositories.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        public void AddCommentToRecette(Comment comment, int idRecette)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetCommentByRecette(int idRecette)
        {
            throw new NotImplementedException();
        }

        public int GetMarktByRecette(int idRecette)
        {
            throw new NotImplementedException();
        }
    }
}