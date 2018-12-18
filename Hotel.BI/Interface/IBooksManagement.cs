using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface IBooksManagement
    {
        IQueryable<Books> GetAll();
        IQueryable<Books> GetAll(Expression<Func<Books, bool>> predicate);
        Books Get(Expression<Func<Books, bool>> predicate);
        void Add(Books entity);
        void Update(Books entity);
        void Delete(Books entity);
        void Delete(int id);
        Books AddOrUpdate(Books entity);
    }
}
