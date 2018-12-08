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
    public class RoomTypesManagement: IRoomTypesManagement
    {
        private OTELEntities _db = new OTELEntities();
        public void Add(RoomTypes entity)
        {
            _db.RoomTypes.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(RoomTypes entity)
        {
            _db.RoomTypes.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.RoomTypes.Remove(GetById(id));
            _db.SaveChanges();
        }

        public RoomTypes Get(Expression<Func<RoomTypes, bool>> predicate)
        {
            return _db.RoomTypes.FirstOrDefault(predicate);
        }

        public IQueryable<RoomTypes> GetAll()
        {
            return _db.RoomTypes.AsQueryable();

        }

        public IQueryable<RoomTypes> GetAll(Expression<Func<RoomTypes, bool>> predicate)
        {
            return _db.RoomTypes.Where(predicate);
        }

        public RoomTypes GetById(int id)
        {
            return _db.RoomTypes.FirstOrDefault(d => d.ID == id);
        }

        public void Update(RoomTypes entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public RoomTypes AddOrUpdate(RoomTypes entity)
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
