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
    public class CustomerManagementController : Controller
    {
        private ICustomersManagement _customersManagement;

        public CustomerManagementController(ICustomersManagement customersManagement)
        {
            _customersManagement = customersManagement;
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
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult NewCustomer(NewCustomerViewModel model)
        {
            try
            {
                _customersManagement.AddOrUpdate(model.Customer);

                this.SuccessMessage("Customer has been saved!");
            }
            catch
            {
                this.ErrorMessage("Customer could not be saved!");
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            _customersManagement.Delete(id);

            this.WarningMessage("Customer has been deleted!");

            return RedirectToAction("Index");
        }
    }
}