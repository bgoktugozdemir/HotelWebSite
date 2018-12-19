using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using Hotel.Model.DataModel;
using WebProje.Areas.Admin.Models.RoomTypeManagement;

namespace WebProje.Areas.Admin.Controllers
{
    public class RoomTypeManagementController : Controller
    {
        private IRoomTypesManagement _roomTypesManagement;

        public RoomTypeManagementController(IRoomTypesManagement roomTypesManagement)
        {
            _roomTypesManagement = roomTypesManagement;
        }

        // GET: Admin/RoomTypeManagement
        public ActionResult Index()
        {
            ShowRoomTypeViewModel model = new ShowRoomTypeViewModel()
            {
                RoomTypeList = _roomTypesManagement.GetAll().OrderBy(r => r.Capacity).ToList()
            };
            return View(model);
        }



        public ActionResult NewRoomType(int? id)
        {
            NewRoomTypeViewModel model = new NewRoomTypeViewModel();
            model.RoomType = id == null ? new RoomTypes() : _roomTypesManagement.Get(r => r.ID == id);

            return View(model);
        }

        [HttpPost]
        public ActionResult NewRoomType(NewRoomTypeViewModel model, HttpPostedFileBase ImageUrl)
        {
            try
            {
                if (ImageUrl != null)
                {
                    //string dosyaAdi = "room" + model.RoomType.ID + ImageUrl.ContentType;
                    
                    model.RoomType.Image = ImageUrl.FileName;

                    var path = Path.Combine("~/Images/Rooms/" + model.RoomType.Image);
                    ImageUrl.SaveAs(Server.MapPath(path));
                }

                _roomTypesManagement.AddOrUpdate(model.RoomType);

                this.SuccessMessage($"<b>{model.RoomType.Name}</b> has been saved!");
            }
            catch (Exception e)
            {
                this.ErrorMessage($"<b>{model.RoomType.Name}</b> could not be saved! ({e.Message})");
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteRoomType(int id)
        {
            try
            {
                var roomType = _roomTypesManagement.Get(r => r.ID == id);

                _roomTypesManagement.Delete(id);

                this.WarningMessage($"<b>{roomType.Name}</b> has been deleted!");
            }
            catch
            {
                this.ErrorMessage("Room Type not found!");
            }
            return RedirectToAction("Index");
        }
    }
}