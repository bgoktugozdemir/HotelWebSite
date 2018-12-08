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
    public class CustomersManagement: ICustomersManagement
    {
        private OTELEntities _db = new OTELEntities();
        public void Add(Customers entity)
        {
            _db.Customers.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Customers entity)
        {
            _db.Customers.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Customers.Remove(GetById(id));
            _db.SaveChanges();
        }

        public Customers Get(Expression<Func<Customers, bool>> predicate)
        {
            return _db.Customers.FirstOrDefault(predicate);
        }

        public IQueryable<Customers> GetAll()
        {
            return _db.Customers.AsQueryable();

        }

        public IQueryable<Customers> GetAll(Expression<Func<Customers, bool>> predicate)
        {
            return _db.Customers.Where(predicate);
        }

        public Customers GetById(int id)
        {
            return _db.Customers.FirstOrDefault(d => d.ID == id);
        }

        public void Update(Customers entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public Customers AddOrUpdate(Customers entity)
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
