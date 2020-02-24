using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngCookingWebApi.Persistance.Repositories.Abstract
{
    interface IRepository<TEntity,TKey> where TEntity:class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey id);
        void Insert(TEntity entity);
        void Update(TEntity entity, TKey id);
        void Delete(TKey id);
    }
}
