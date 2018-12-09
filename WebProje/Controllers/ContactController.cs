using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Hotel.BI.Interface;
using Hotel.Model.DataModel;
using WebProje.Models.Contact;

namespace WebProje.Controllers
{
    public class ContactController : Controller
    {
        private ISettingsManagement _settingsManagement;
        private IContactFormsManagement _contactFormsManagement;

        public ContactController(ISettingsManagement settingsManagement, IContactFormsManagement contactFormsManagement)
        {
            _settingsManagement = settingsManagement;
            _contactFormsManagement = contactFormsManagement;
        }

        // GET: Contact
        public ActionResult Index()
        {
            ContactViewModel model = new ContactViewModel
            {
                SettingsList = _settingsManagement.GetAll().ToList()
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ContactViewModel model)
        {
            try
            {
                //string ip = System.Web.HttpContext.Current.Request.UserHostAddress;

                //ContactForms contact = new ContactForms
                //{
                //    Name = model.Name,
                //    Email = model.Email,
                //    Subject = model.Subject,
                //    Message = model.Message,
                //    IpAddress = ip,
                //    SendedAt = DateTime.Now
                //};

                //_contactFormsManagement.Add(contact);
                TempData["IsPosted"] = true;
            }
            catch
            {
                TempData["IsPosted"] = false;
            }

            return RedirectToAction("Index");
        }
    }
}