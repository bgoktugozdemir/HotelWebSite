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
    public class BooksManagement : IBooksManagement
    {
        private OTELEntities _db = new OTELEntities();
        public void Add(Books entity)
        {
            _db.Books.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Books entity)
        {
            _db.Books.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Books.Remove(GetById(id));
            _db.SaveChanges();
        }

        public Books Get(Expression<Func<Books, bool>> predicate)
        {
            return _db.Books.FirstOrDefault(predicate);
        }

        public IQueryable<Books> GetAll()
        {
            return _db.Books.AsQueryable();

        }

        public IQueryable<Books> GetAll(Expression<Func<Books, bool>> predicate)
        {
            return _db.Books.Where(predicate);
        }

        public Books GetById(int id)
        {
            return _db.Books.FirstOrDefault(d => d.ID == id);
        }

        public void Update(Books entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public Books AddOrUpdate(Books entity)
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
