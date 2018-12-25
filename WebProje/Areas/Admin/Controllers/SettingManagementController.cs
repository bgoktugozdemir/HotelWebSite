using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using Hotel.Model.DataModel;
using WebProje.Areas.Admin.Models.SettingManagement;

namespace WebProje.Areas.Admin.Controllers
{
    [Authorize]
    public class SettingManagementController : Controller
    {
        private ISettingsManagement _settingsManagement;

        public SettingManagementController(ISettingsManagement settingsManagement)
        {
            _settingsManagement = settingsManagement;
        }

        // GET: Admin/SettingManagement
        public ActionResult Index()
        {
            ShowSettingViewModel model = new ShowSettingViewModel()
            {
                SettingList = _settingsManagement.GetAll().OrderBy(s=>s.Name).ToList()
            };
            return View(model);
        }

        public ActionResult NewSetting(int? id)
        {
            NewSettingViewModel model = new NewSettingViewModel();
            if (id == null)
            {
                model.Setting = new Settings();
            }
            else
            {
                model.Setting = _settingsManagement.Get(s => s.ID == id);
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult NewSetting(NewSettingViewModel model)
        {
            try
            {
                _settingsManagement.AddOrUpdate(model.Setting);
                this.SuccessMessage($"Setting <b>({model.Setting.Name})</b> has been saved!");
            }
            catch (Exception e)
            {
                this.ErrorMessage($"Setting <b>({model.Setting.Name})</b> could not saved! ({e.Message})");
            }

            return RedirectToAction("Index");
        }
    }
}