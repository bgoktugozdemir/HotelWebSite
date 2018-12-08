using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface IImagesManagement
    {
        IQueryable<Images> GetAll();
        IQueryable<Images> GetAll(Expression<Func<Images, bool>> predicate);
        Images Get(Expression<Func<Images, bool>> predicate);
        void Add(Images entity);
        void Update(Images entity);
        void Delete(Images entity);
        void Delete(int id);
        Images AddOrUpdate(Images entity);
    }
}
