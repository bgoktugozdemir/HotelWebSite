using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using Hotel.Model.DataModel;
using WebProje.Areas.Admin.Models.RoomManagement;

namespace WebProje.Areas.Admin.Controllers
{
    public class RoomManagementController : Controller
    {
        private IRoomsManagement _roomsManagement;
        private IRoomTypesManagement _roomTypesManagement;
        private IBooksManagement _booksManagement;

        public RoomManagementController(IRoomsManagement roomsManagement, IRoomTypesManagement roomTypesManagement, IBooksManagement booksManagement)
        {
            _roomsManagement = roomsManagement;
            _roomTypesManagement = roomTypesManagement;
            _booksManagement = booksManagement;
        }

        // GET: Admin/RoomManagement
        public ActionResult Index()
        {
            ShowRoomViewModel model = new ShowRoomViewModel()
            {
                RoomList = _roomsManagement.GetAll().OrderBy(r => r.ID).ToList(),
                BookList = _booksManagement.GetAll().OrderByDescending(b=>b.ArrivalDate).ToList()
            };
            foreach (var room in model.RoomList)
            {
                List<Books> books = _booksManagement.GetAll(b => b.RoomID == room.ID && !b.IsCancelled).OrderByDescending(b => b.ArrivalDate).Take(1).ToList();
                if (books.Count > 0)
                {
                    if (DateHelper.IncludeDate(books[books.Count - 1].ArrivalDate, books[books.Count - 1].DepartureDate))
                    {
                        room.Books.Add(books[books.Count - 1]);
                    }
                }
            }
            return View(model);
        }

        public ActionResult NewRoom(int? id)
        {
            NewRoomViewModel model = new NewRoomViewModel()
            {
                RoomTypeList = _roomTypesManagement.GetAll().OrderBy(r => r.Capacity).ToList()
            };

            if (id == null)
            {
                model.Room = new Rooms();
            }
            else
            {
                model.Room = _roomsManagement.Get(r => r.ID == id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult NewRoom(NewRoomViewModel model)
        {
            try
            {
                _roomsManagement.AddOrUpdate(model.Room);

                this.SuccessMessage($"Room <b>({model.Room.RoomNo})</b> has been saved!");
            }
            catch (DbUpdateException e)
            {
                this.ErrorMessage($"Room <b>({model.Room.RoomNo})</b> already exist! ({e.Message})");
            }
            catch (Exception e)
            {
                this.ErrorMessage($"Room <b>({model.Room.RoomNo})</b> could not add! ({e.Message})");
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteRoom(int id)
        {
            try
            {
                var room = _roomsManagement.Get(r => r.ID == id);
                _roomsManagement.Delete(id);

                this.WarningMessage($"<b>{room.RoomNo}</b> has been deleted!");
            }
            catch
            {
                this.ErrorMessage($"Room No <b>{id}</b> not found!");
            }
            return RedirectToAction("Index");
        }
    }
}