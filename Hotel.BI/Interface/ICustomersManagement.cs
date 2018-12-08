using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface ICustomersManagement
    {
        IQueryable<Customers> GetAll();
        IQueryable<Customers> GetAll(Expression<Func<Customers, bool>> predicate);
        Customers Get(Expression<Func<Customers, bool>> predicate);
        void Add(Customers entity);
        void Update(Customers entity);
        void Delete(Customers entity);
        void Delete(int id);
        Customers AddOrUpdate(Customers entity);
    }
}
