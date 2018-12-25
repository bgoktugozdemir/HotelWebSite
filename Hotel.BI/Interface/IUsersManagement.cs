using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface IUsersManagement
    {
        IQueryable<Users> GetAll();
        IQueryable<Users> GetAll(Expression<Func<Users, bool>> predicate);
        Users Get(Expression<Func<Users, bool>> predicate);
        void Add(Users entity);
        void Update(Users entity);
        void Delete(Users entity);
        void Delete(int id);
        Users AddOrUpdate(Users entity);
    }
}
