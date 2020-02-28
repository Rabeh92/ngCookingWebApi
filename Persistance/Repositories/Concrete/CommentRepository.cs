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
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddCommentToRecette(Comment comment)
        {
            _context.Comments.Add(comment);
        }

        public IEnumerable<Comment> GetCommentByRecette(int idRecette)
        {
            return _context.Comments
                .Where(c => c.Id == idRecette)
                .ToList();
        }

        public double GetMarkByRecette(int idRecette)
        {
            return _context.Comments
                .Where(c => c.RecetteId == idRecette)
                .Average(c => c.Mark);
        }
    }
}