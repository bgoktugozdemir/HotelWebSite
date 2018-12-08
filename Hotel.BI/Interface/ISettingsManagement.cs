using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface ISettingsManagement
    {
        IQueryable<Settings> GetAll();
        IQueryable<Settings> GetAll(Expression<Func<Settings, bool>> predicate);
        Settings Get(Expression<Func<Settings, bool>> predicate);
        void Add(Settings entity);
        void Update(Settings entity);
        void Delete(Settings entity);
        void Delete(int id);
        Settings AddOrUpdate(Settings entity);
    }
}
