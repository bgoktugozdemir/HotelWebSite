﻿using System;
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
    public class ContactFormsManagement : IContactFormsManagement
    {
        private OTELEntities _db = new OTELEntities();
        public void Add(ContactForms entity)
        {
            _db.ContactForms.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(ContactForms entity)
        {
            _db.ContactForms.Remove(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.ContactForms.Remove(GetById(id));
            _db.SaveChanges();
        }

        public ContactForms Get(Expression<Func<ContactForms, bool>> predicate)
        {
            return _db.ContactForms.FirstOrDefault(predicate);
        }

        public IQueryable<ContactForms> GetAll()
        {
            return _db.ContactForms.AsQueryable();

        }

        public IQueryable<ContactForms> GetAll(Expression<Func<ContactForms, bool>> predicate)
        {
            return _db.ContactForms.Where(predicate);
        }

        public ContactForms GetById(int id)
        {
            return _db.ContactForms.FirstOrDefault(d => d.ID == id);
        }

        public void Update(ContactForms entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public ContactForms AddOrUpdate(ContactForms entity)
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
