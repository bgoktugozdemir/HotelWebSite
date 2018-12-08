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
    public class ServicesManagement: IServicesManagement
    {
        private OTELEntities _db = new OTELEntities();
        public void Add(Services entity)
        {
            _db.Services.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Services entity)
        {
            _db.Services.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Services.Remove(GetById(id));
            _db.SaveChanges();
        }

        public Services Get(Expression<Func<Services, bool>> predicate)
        {
            return _db.Services.FirstOrDefault(predicate);
        }

        public IQueryable<Services> GetAll()
        {
            return _db.Services.AsQueryable();

        }

        public IQueryable<Services> GetAll(Expression<Func<Services, bool>> predicate)
        {
            return _db.Services.Where(predicate);
        }

        public Services GetById(int id)
        {
            return _db.Services.FirstOrDefault(d => d.ID == id);
        }

        public void Update(Services entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public Services AddOrUpdate(Services entity)
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
