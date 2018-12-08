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
    public class SettingsManagement: ISettingsManagement
    {
        private OTELEntities _db = new OTELEntities();
        public void Add(Settings entity)
        {
            _db.Settings.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Settings entity)
        {
            _db.Settings.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Settings.Remove(GetById(id));
            _db.SaveChanges();
        }

        public Settings Get(Expression<Func<Settings, bool>> predicate)
        {
            return _db.Settings.FirstOrDefault(predicate);
        }

        public IQueryable<Settings> GetAll()
        {
            return _db.Settings.AsQueryable();

        }

        public IQueryable<Settings> GetAll(Expression<Func<Settings, bool>> predicate)
        {
            return _db.Settings.Where(predicate);
        }

        public Settings GetById(int id)
        {
            return _db.Settings.FirstOrDefault(d => d.ID == id);
        }

        public void Update(Settings entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public Settings AddOrUpdate(Settings entity)
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
