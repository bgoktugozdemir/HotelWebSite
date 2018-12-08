using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using WebProje.Models.Contact;

namespace WebProje.Controllers
{
    public class ContactController : Controller
    {
        private ISettingsManagement _settingsManagement;

        public ContactController(ISettingsManagement settingsManagement)
        {
            _settingsManagement = settingsManagement;
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
    }
}