using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface IPostsManagement
    {
        IQueryable<Posts> GetAll();
        IQueryable<Posts> GetAll(Expression<Func<Posts, bool>> predicate);
        Posts Get(Expression<Func<Posts, bool>> predicate);
        void Add(Posts entity);
        void Update(Posts entity);
        void Delete(Posts entity);
        void Delete(int id);
        Posts AddOrUpdate(Posts entity);
    }
}
