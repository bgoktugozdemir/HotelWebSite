using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using Hotel.BI.Interface;
using Hotel.Core.Enum;
using Hotel.Model.DataModel;
using WebProje.Areas.Admin.Models.CustomerManagement;

namespace WebProje.Areas.Admin.Controllers
{
    [Authorize]
    public class CustomerManagementController : Controller
    {
        private ICustomersManagement _customersManagement;
        private IBooksManagement _booksManagement;

        public CustomerManagementController(ICustomersManagement customersManagement, IBooksManagement booksManagement)
        {
            _customersManagement = customersManagement;
            _booksManagement = booksManagement;
        }

        // GET: Admin/CustomerManagement
        public ActionResult Index()
        {
            ShowCustomerViewModel model = new ShowCustomerViewModel()
            {
                CustomerList = _customersManagement.GetAll().OrderBy(d=>d.Name).ToList()
            };
            return View(model);
        }

        public ActionResult NewCustomer(int? id)
        {
            NewCustomerViewModel model = new NewCustomerViewModel();

            model.GenderList = EnumHelpers.ConvertEnumToList(typeof(Genders));

            List<string> CountryList = new List<string>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(CountryList.Contains(R.EnglishName)))
                {
                    CountryList.Add(R.EnglishName);
                }
            }

            CountryList.Sort();
            ViewBag.CountryList = CountryList;

            if (id == null)
            {
                model.Customer = new Customers();
            }
            else
            {
                model.Customer = _customersManagement.Get(d => d.ID == id);
                model.BookList = _booksManagement.GetAll(b => b.CustomerID == id && !b.IsCancelled).OrderBy(b => b.ArrivalDate).ToList();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult NewCustomer(NewCustomerViewModel model)
        {
            try
            {
                _customersManagement.AddOrUpdate(model.Customer);

                this.SuccessMessage($"<strong>{model.Customer.Name}</strong> has been saved!");
            }
            catch
            {
                this.ErrorMessage($"<strong>{model.Customer.Name}</strong> could not be saved!");
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var name = _customersManagement.Get(c => c.ID == id).Name;
            _customersManagement.Delete(id);

            this.WarningMessage($"<strong>{name}</strong> has been deleted!");

            return RedirectToAction("Index");
        }
    }
}