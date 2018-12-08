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
    public class ImagesManagement: IImagesManagement
    {
        private OTELEntities _db = new OTELEntities();
        public void Add(Images entity)
        {
            _db.Images.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Images entity)
        {
            _db.Images.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Images.Remove(GetById(id));
            _db.SaveChanges();
        }

        public Images Get(Expression<Func<Images, bool>> predicate)
        {
            return _db.Images.FirstOrDefault(predicate);
        }

        public IQueryable<Images> GetAll()
        {
            return _db.Images.AsQueryable();

        }

        public IQueryable<Images> GetAll(Expression<Func<Images, bool>> predicate)
        {
            return _db.Images.Where(predicate);
        }

        public Images GetById(int id)
        {
            return _db.Images.FirstOrDefault(d => d.ID == id);
        }

        public void Update(Images entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public Images AddOrUpdate(Images entity)
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
