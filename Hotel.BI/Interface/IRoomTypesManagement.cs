using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface IRoomTypesManagement
    {
        IQueryable<RoomTypes> GetAll();
        IQueryable<RoomTypes> GetAll(Expression<Func<RoomTypes, bool>> predicate);
        RoomTypes Get(Expression<Func<RoomTypes, bool>> predicate);
        void Add(RoomTypes entity);
        void Update(RoomTypes entity);
        void Delete(RoomTypes entity);
        void Delete(int id);
        RoomTypes AddOrUpdate(RoomTypes entity);
    }
}
