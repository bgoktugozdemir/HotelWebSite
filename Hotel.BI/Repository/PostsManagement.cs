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
    public class PostsManagement: IPostsManagement
    {
        private OTELEntities _db = new OTELEntities();
        public void Add(Posts entity)
        {
            _db.Posts.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Posts entity)
        {
            _db.Posts.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Posts.Remove(GetById(id));
            _db.SaveChanges();
        }

        public Posts Get(Expression<Func<Posts, bool>> predicate)
        {
            return _db.Posts.FirstOrDefault(predicate);
        }

        public IQueryable<Posts> GetAll()
        {
            return _db.Posts.AsQueryable();

        }

        public IQueryable<Posts> GetAll(Expression<Func<Posts, bool>> predicate)
        {
            return _db.Posts.Where(predicate);
        }

        public Posts GetById(int id)
        {
            return _db.Posts.FirstOrDefault(d => d.ID == id);
        }

        public void Update(Posts entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public Posts AddOrUpdate(Posts entity)
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
