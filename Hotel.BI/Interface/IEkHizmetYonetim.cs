using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface IEkHizmetYonetim
    {
        IQueryable<Rezervasyon_EkHizmet> GetAll();
        IQueryable<Rezervasyon_EkHizmet> GetAll(Expression<Func<Rezervasyon_EkHizmet, bool>> predicate);
        Rezervasyon_EkHizmet Get(Expression<Func<Rezervasyon_EkHizmet, bool>> predicate);
        void Add(Rezervasyon_EkHizmet entity);
        void Update(Rezervasyon_EkHizmet entity);
        void Delete(Rezervasyon_EkHizmet entity);
        void Delete(int id);
        Rezervasyon_EkHizmet AddOrUpdate(Rezervasyon_EkHizmet entity);
    }
}
