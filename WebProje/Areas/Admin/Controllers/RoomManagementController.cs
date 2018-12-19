using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using WebProje.Areas.Admin.Models.RoomManagement;

namespace WebProje.Areas.Admin.Controllers
{
    public class RoomManagementController : Controller
    {
        private IRoomsManagement _roomsManagement;
        private IRoomTypesManagement _roomTypesManagement;

        public RoomManagementController(IRoomsManagement roomsManagement, IRoomTypesManagement roomTypesManagement)
        {
            _roomsManagement = roomsManagement;
            _roomTypesManagement = roomTypesManagement;
        }

        // GET: Admin/RoomManagement
        public ActionResult Index()
        {
            ShowRoomViewModel model = new ShowRoomViewModel()
            {
                RoomList = _roomsManagement.GetAll().OrderBy(r => r.RoomNo).ToList()
            };
            return View(model);
        }
    }
}