using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface ITestimonialsManagement
    {
        IQueryable<Testimonials> GetAll();
        IQueryable<Testimonials> GetAll(Expression<Func<Testimonials, bool>> predicate);
        Testimonials Get(Expression<Func<Testimonials, bool>> predicate);
        void Add(Testimonials entity);
        void Update(Testimonials entity);
        void Delete(Testimonials entity);
        void Delete(int id);
        Testimonials AddOrUpdate(Testimonials entity);
    }
}
