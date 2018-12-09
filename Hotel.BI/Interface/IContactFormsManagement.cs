using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model.DataModel;

namespace Hotel.BI.Interface
{
    public interface IContactFormsManagement
    {
        IQueryable<ContactForms> GetAll();
        IQueryable<ContactForms> GetAll(Expression<Func<ContactForms, bool>> predicate);
        ContactForms Get(Expression<Func<ContactForms, bool>> predicate);
        void Add(ContactForms entity);
        void Update(ContactForms entity);
        void Delete(ContactForms entity);
        void Delete(int id);
        ContactForms AddOrUpdate(ContactForms entity);
    }
}
