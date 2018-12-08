using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface IPagesManagement
    {
        IQueryable<Pages> GetAll();
        IQueryable<Pages> GetAll(Expression<Func<Pages, bool>> predicate);
        Pages Get(Expression<Func<Pages, bool>> predicate);
        void Add(Pages entity);
        void Update(Pages entity);
        void Delete(Pages entity);
        void Delete(int id);
        Pages AddOrUpdate(Pages entity);
    }
}
