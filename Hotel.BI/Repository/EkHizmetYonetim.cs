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
    public class EkHizmetYonetim: IEkHizmetYonetim
    {
        private HOTELEntities _db = new HOTELEntities();
        public void Add(Rezervasyon_EkHizmet entity)
        {
            _db.Rezervasyon_EkHizmet.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Rezervasyon_EkHizmet entity)
        {
            _db.Rezervasyon_EkHizmet.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Rezervasyon_EkHizmet.Remove(GetById(id));
            _db.SaveChanges();
        }

        public Rezervasyon_EkHizmet Get(Expression<Func<Rezervasyon_EkHizmet, bool>> predicate)
        {
            return _db.Rezervasyon_EkHizmet.FirstOrDefault(predicate);
        }

        public IQueryable<Rezervasyon_EkHizmet> GetAll()
        {
            return _db.Rezervasyon_EkHizmet.AsQueryable();

        }

        public IQueryable<Rezervasyon_EkHizmet> GetAll(Expression<Func<Rezervasyon_EkHizmet, bool>> predicate)
        {
            return _db.Rezervasyon_EkHizmet.Where(predicate);
        }

        public Rezervasyon_EkHizmet GetById(int id)
        {
            return _db.Rezervasyon_EkHizmet.FirstOrDefault(d => d.Id == id);
        }

        public void Update(Rezervasyon_EkHizmet entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public Rezervasyon_EkHizmet AddOrUpdate(Rezervasyon_EkHizmet entity)
        {
            try
            {
                _db.Entry(entity).State = entity.Id == 0 ?
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
