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
    public class EmployeesManagement: IEmployeesManagement
    {
        private OTELEntities _db = new OTELEntities();
        public void Add(Employees entity)
        {
            _db.Employees.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Employees entity)
        {
            _db.Employees.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Employees.Remove(GetById(id));
            _db.SaveChanges();
        }

        public Employees Get(Expression<Func<Employees, bool>> predicate)
        {
            return _db.Employees.FirstOrDefault(predicate);
        }

        public IQueryable<Employees> GetAll()
        {
            return _db.Employees.AsQueryable();

        }

        public IQueryable<Employees> GetAll(Expression<Func<Employees, bool>> predicate)
        {
            return _db.Employees.Where(predicate);
        }

        public Employees GetById(int id)
        {
            return _db.Employees.FirstOrDefault(d => d.ID == id);
        }

        public void Update(Employees entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public Employees AddOrUpdate(Employees entity)
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
