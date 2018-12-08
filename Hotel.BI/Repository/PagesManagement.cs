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
    public class PagesManagement: IPagesManagement
    {
        private OTELEntities _db = new OTELEntities();
        public void Add(Pages entity)
        {
            _db.Pages.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Pages entity)
        {
            _db.Pages.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Pages.Remove(GetById(id));
            _db.SaveChanges();
        }

        public Pages Get(Expression<Func<Pages, bool>> predicate)
        {
            return _db.Pages.FirstOrDefault(predicate);
        }

        public IQueryable<Pages> GetAll()
        {
            return _db.Pages.AsQueryable();

        }

        public IQueryable<Pages> GetAll(Expression<Func<Pages, bool>> predicate)
        {
            return _db.Pages.Where(predicate);
        }

        public Pages GetById(int id)
        {
            return _db.Pages.FirstOrDefault(d => d.ID == id);
        }

        public void Update(Pages entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public Pages AddOrUpdate(Pages entity)
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
