using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface IRoomsManagement
    {
        IQueryable<Rooms> GetAll();
        IQueryable<Rooms> GetAll(Expression<Func<Rooms, bool>> predicate);
        Rooms Get(Expression<Func<Rooms, bool>> predicate);
        void Add(Rooms entity);
        void Update(Rooms entity);
        void Delete(Rooms entity);
        void Delete(int id);
        Rooms AddOrUpdate(Rooms entity);
    }
}
