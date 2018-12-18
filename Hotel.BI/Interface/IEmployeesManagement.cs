using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface IEmployeesManagement
    {
        IQueryable<Employees> GetAll();
        IQueryable<Employees> GetAll(Expression<Func<Employees, bool>> predicate);
        Employees Get(Expression<Func<Employees, bool>> predicate);
        void Add(Employees entity);
        void Update(Employees entity);
        void Delete(Employees entity);
        void Delete(int id);
        Employees AddOrUpdate(Employees entity);
    }
}
