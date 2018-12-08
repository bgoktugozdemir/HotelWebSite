using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface IServicesManagement
    {
        IQueryable<Services> GetAll();
        IQueryable<Services> GetAll(Expression<Func<Services, bool>> predicate);
        Services Get(Expression<Func<Services, bool>> predicate);
        void Add(Services entity);
        void Update(Services entity);
        void Delete(Services entity);
        void Delete(int id);
        Services AddOrUpdate(Services entity);
    }
}
