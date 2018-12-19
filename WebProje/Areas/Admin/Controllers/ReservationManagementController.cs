using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
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
            Books book = new Books();
            try
            {
                book = model.Book;

                if (model.Book.ID == 0)
                {
                    book.BookingDate = DateTime.Now;
                }

                //TODO: Şu anda giriş yapılmış kullanıcının idsi alınacak.
                //TODO: Discount format farkından dolayı alınamıyor ve götürülemiyor.
                book.Rooms = _roomsManagement.Get(r => r.ID == book.RoomID);
                book.Customers = _customersManagement.Get(c => c.ID == book.CustomerID);
                book.Price = (decimal) ((float) model.Book.Rooms.RoomTypes.Price * (1 - model.Book.Discount) * model.Book.Night);

                _booksManagement.AddOrUpdate(book);
                this.SuccessMessage("Reservation has been saved!");
            }
            catch (Exception e)
            {
                this.ErrorMessage("Reservation could not be saved! ("+e.Message+")");
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