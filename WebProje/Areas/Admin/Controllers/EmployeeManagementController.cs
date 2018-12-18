using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using Hotel.Core.Enum;
using Hotel.Model.DataModel;
using WebProje.Areas.Admin.Models.EmployeeManagement;

namespace WebProje.Areas.Admin.Controllers
{
    public class EmployeeManagementController : Controller
    {
        private IEmployeesManagement _employeesManagement;

        public EmployeeManagementController(IEmployeesManagement employeesManagement)
        {
            _employeesManagement = employeesManagement;
        }

        // GET: Admin/Employee
        public ActionResult Index()
        {
            ShowEmployeeViewModel model = new ShowEmployeeViewModel()
            {
                EmployeeList = _employeesManagement.GetAll().OrderBy(d=>d.Name).ToList()
            };

            return View(model);
        }

        public ActionResult NewEmployee(int? id)
        {
            NewEmployeeViewModel model = new NewEmployeeViewModel();

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
                model.Employee = new Employees();
            }
            else
            {
                model.Employee = _employeesManagement.Get(d => d.ID == id);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult NewEmployee(NewEmployeeViewModel model)
        {
            try
            {
                _employeesManagement.AddOrUpdate(model.Employee);

                this.SuccessMessage("Employee has been saved!");
            }
            catch
            {
                this.ErrorMessage("Employee could not be saved!");
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteEmployee(int id)
        {
            _employeesManagement.Delete(id);

            this.WarningMessage("Employee has been deleted!");

            return RedirectToAction("Index");
        }
    }
}