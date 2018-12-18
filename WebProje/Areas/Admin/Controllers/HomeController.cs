using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public HomeController(IContactFormsManagement contactFormsManagement, IBooksManagement booksManagement, ICustomersManagement customersManagement, IRoomsManagement roomsManagement, IRoomTypesManagement roomTypesManagement)
        {
            _contactFormsManagement = contactFormsManagement;
            _booksManagement = booksManagement;
            _customersManagement = customersManagement;
            _roomsManagement = roomsManagement;
            _roomTypesManagement = roomTypesManagement;
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            double totalEarning = 0;
            var booksList = _booksManagement.GetAll().OrderByDescending(m => m.BookingDate).ToList();

            foreach (var item in booksList)
            {
                totalEarning += ((float)item.Price * (1 - item.Discount));
            }

            HomeViewModel model = new HomeViewModel
            {
                ContactFormsList = _contactFormsManagement.GetAll().OrderByDescending(m=>m.SendedAt).Take(8).ToList(),
                BooksList = booksList.Take(8).ToList(),
                CustomerCount = _customersManagement.GetAll().Count(),
                BookingCount = _booksManagement.GetAll().Count(),
                RoomCount = _roomsManagement.GetAll().Count(),
                TotalEarning = totalEarning,
                RoomTypeList = _roomTypesManagement.GetAll().ToList()
            };


            return View(model);
        }
    }
}