using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.BI.Interface;
using Hotel.Model.DataModel;

namespace Hotel.BI.Repository
{
    public class TestimonialsManagement: ITestimonialsManagement
    {
        private OTELEntities _db = new OTELEntities();
        public void Add(Testimonials entity)
        {
            _db.Testimonials.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Testimonials entity)
        {
            _db.Testimonials.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Testimonials.Remove(GetById(id));
            _db.SaveChanges();
        }

        public Testimonials Get(Expression<Func<Testimonials, bool>> predicate)
        {
            return _db.Testimonials.FirstOrDefault(predicate);
        }

        public IQueryable<Testimonials> GetAll()
        {
            return _db.Testimonials.AsQueryable();

        }

        public IQueryable<Testimonials> GetAll(Expression<Func<Testimonials, bool>> predicate)
        {
            return _db.Testimonials.Where(predicate);
        }

        public Testimonials GetById(int id)
        {
            return _db.Testimonials.FirstOrDefault(d => d.ID == id);
        }

        public void Update(Testimonials entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public Testimonials AddOrUpdate(Testimonials entity)
        {
            try
            {
                _db.Entry(entity).State = entity.ID == 0 ?
                    EntityState.Added :
                    EntityState.Modified;
                _db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }


            return entity;
        }
    }
}
