using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Hotel.BI.Interface;
using WebProje.Areas.Admin.Models.Home;

namespace WebProje.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private IContactFormsManagement _contactFormsManagement;
        private IBooksManagement _booksManagement;
        private ICustomersManagement _customersManagement;
        private IRoomsManagement _roomsManagement;
        private IRoomTypesManagement _roomTypesManagement;
        private ITestimonialsManagement _testimonialsManagement;

        public HomeController(IContactFormsManagement contactFormsManagement, IBooksManagement booksManagement, ICustomersManagement customersManagement, IRoomsManagement roomsManagement, IRoomTypesManagement roomTypesManagement, ITestimonialsManagement testimonialsManagement)
        {
            _contactFormsManagement = contactFormsManagement;
            _booksManagement = booksManagement;
            _customersManagement = customersManagement;
            _roomsManagement = roomsManagement;
            _roomTypesManagement = roomTypesManagement;
            _testimonialsManagement = testimonialsManagement;
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            double totalEarning = 0;
            var book = _booksManagement.Get(d => d.ID == 7);
            var booksList = _booksManagement.GetAll(b => DateTime.Equals(b.ArrivalDate, DateTime.Today) && !b.IsCancelled && !b.IsCheckIn).OrderBy(m => m.BookingDate).ToList();
            var allBooksList = _booksManagement.GetAll(d=>!d.IsCancelled).ToList();

            foreach (var item in allBooksList)
            {
                totalEarning += ((float)item.Price * (1 - item.Discount) * item.Night);
            }

            HomeViewModel model = new HomeViewModel
            {
                ContactFormsList = _contactFormsManagement.GetAll().OrderByDescending(m=>m.SendedAt).Take(8).ToList(),
                BooksList = booksList.ToList(),
                CustomerCount = _customersManagement.GetAll().Count(),
                BookingCount = _booksManagement.GetAll().Count(),
                RoomCount = _roomsManagement.GetAll().Count(),
                TotalEarning = totalEarning,
                RoomTypeList = _roomTypesManagement.GetAll().ToList(),
                TestimonialList = _testimonialsManagement.GetAll(t=>t.IsShow == true).OrderBy(t=>t.OrderSort).ToList()
            };

            return View(model);
        }
    }
}