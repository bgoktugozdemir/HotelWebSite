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
    public class UsersManagement : IUsersManagement
    {
        private OTELEntities _db = new OTELEntities();
        public void Add(Users entity)
        {
            _db.Users.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Users entity)
        {
            _db.Users.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Users.Remove(GetById(id));
            _db.SaveChanges();
        }

        public Users Get(Expression<Func<Users, bool>> predicate)
        {
            return _db.Users.FirstOrDefault(predicate);
        }

        public IQueryable<Users> GetAll()
        {
            return _db.Users.AsQueryable();

        }

        public IQueryable<Users> GetAll(Expression<Func<Users, bool>> predicate)
        {
            return _db.Users.Where(predicate);
        }

        public Users GetById(int id)
        {
            return _db.Users.FirstOrDefault(d => d.ID == id);
        }

        public void Update(Users entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public Users AddOrUpdate(Users entity)
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
