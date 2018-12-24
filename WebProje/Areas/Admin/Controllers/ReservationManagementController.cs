using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using Hotel.Core.Exceptions;
using Hotel.Model.DataModel;
using WebProje.Areas.Admin.Models.ReservationManagement;

namespace WebProje.Areas.Admin.Controllers
{
    public class ReservationManagementController : Controller
    {
        private IBooksManagement _booksManagement;
        private IRoomsManagement _roomsManagement;
        private IRoomTypesManagement _roomTypesManagement;
        private ICustomersManagement _customersManagement;
        private IEmployeesManagement _employeesManagement;

        public ReservationManagementController(IBooksManagement booksManagement, IRoomsManagement roomsManagement, IRoomTypesManagement roomTypesManagement, ICustomersManagement customersManagement, IEmployeesManagement employeesManagement)
        {
            _booksManagement = booksManagement;
            _roomsManagement = roomsManagement;
            _roomTypesManagement = roomTypesManagement;
            _customersManagement = customersManagement;
            _employeesManagement = employeesManagement;
        }

        // GET: Admin/ReservationManagement
        public ActionResult Index()
        {
            ShowReservationViewModel model = new ShowReservationViewModel
            {
                BookList = _booksManagement.GetAll(b => b.DepartureDate == null).OrderBy(b => b.ArrivalDate).ToList(),
                OldBookList = _booksManagement.GetAll(b => b.DepartureDate != null).OrderBy(b => b.ArrivalDate).ToList()
            };

            return View(model);
        }

        public ActionResult NewReservation(int? id)
        {
            NewReservationViewModel model = new NewReservationViewModel()
            {
                RoomList = _roomsManagement.GetAll().ToList(),
                RoomTypeList = _roomTypesManagement.GetAll().ToList(),
                CustomerList = _customersManagement.GetAll().ToList()
            };

            if (id == null)
            {
                model.Book = new Books();
            }
            else
            {
                model.Book = _booksManagement.Get(d => d.ID == id);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult NewReservation(NewReservationViewModel model)
        {
            try
            {
                var room = _roomsManagement.Get(r => r.ID == model.Book.RoomID);
                var roomType = room.RoomTypeID;
                if (model.Book.ID == 0)
                {
                    var books = _booksManagement.GetAll(b => b.RoomID == room.ID).OrderByDescending(b=>b.ArrivalDate).ToList();

                    if (books.Count > 0)
                    {
                        foreach (var book in books)
                        {
                            if (book.CustomerID != model.Book.CustomerID && (DateHelper.IncludeDate(model.Book.ArrivalDate, book.ArrivalDate, book.DepartureDate) || DateHelper.IncludeDate(model.Book.DepartureDate, book.ArrivalDate, book.DepartureDate)))
                            {
                                var roomNo = _roomsManagement.Get(r => r.ID == model.Book.RoomID).RoomNo;
                                throw new UnavailableRoomException(roomNo);
                            }
                        }
                    }
                }

                var price = _roomTypesManagement.Get(r => r.ID == roomType).Price;

                if (model.Book.ID == 0)
                {
                    model.Book.BookingDate = DateTime.Now;
                }

                //TODO: Şu anda giriş yapılmış çalışanın idsi alınacak.
                model.Book.Night = (int) (model.Book.DepartureDate - model.Book.ArrivalDate).TotalDays;
                model.Book.Discount = model.Discount / 100;
                model.Book.Price = (decimal) ((float) price * (1 - model.Book.Discount) * model.Book.Night);

                _booksManagement.AddOrUpdate(model.Book);
                this.SuccessMessage("Reservation has been saved!");
            }
            catch (UnavailableRoomException e)
            {
                this.ErrorMessage(e.Message);
                return RedirectToAction("NewReservation", "ReservationManagement");
            }
            catch (Exception e)
            {
                this.ErrorMessage($"Reservation could not be saved! ({e.Message})");
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteReservation(int id)
        {
            _booksManagement.Delete(id);

            this.WarningMessage("Reservation has been deleted!");

            return RedirectToAction("Index");
        }
    }
}