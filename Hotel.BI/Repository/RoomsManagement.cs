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
    public class RoomsManagement : IRoomsManagement
    {
        private OTELEntities _db = new OTELEntities();
        public void Add(Rooms entity)
        {
            _db.Rooms.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Rooms entity)
        {
            _db.Rooms.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Rooms.Remove(GetById(id));
            _db.SaveChanges();
        }

        public Rooms Get(Expression<Func<Rooms, bool>> predicate)
        {
            return _db.Rooms.FirstOrDefault(predicate);
        }

        public IQueryable<Rooms> GetAll()
        {
            return _db.Rooms.AsQueryable();

        }

        public IQueryable<Rooms> GetAll(Expression<Func<Rooms, bool>> predicate)
        {
            return _db.Rooms.Where(predicate);
        }

        public Rooms GetById(int id)
        {
            return _db.Rooms.FirstOrDefault(d => d.ID == id);
        }

        public void Update(Rooms entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public Rooms AddOrUpdate(Rooms entity)
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
