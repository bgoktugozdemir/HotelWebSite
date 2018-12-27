using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using Hotel.Model.DataModel;
using WebProje.Areas.Admin;
using WebProje.Models.Home;
using WebProje.Models.Shared;

namespace WebProje.Controllers
{
    public class HomeController : Controller
    {
        private IRoomTypesManagement _roomTypesManagement;
        private IServicesManagement _servicesManagement;
        private IPagesManagement _pagesManagement;
        private ITestimonialsManagement _testimonialsManagement;
        private IPostsManagement _postsManagement;
        private ICustomersManagement _customersManagement;
        private IRoomsManagement _roomsManagement;
        private IBooksManagement _booksManagement;

        public HomeController(IRoomTypesManagement roomTypesManagement, IServicesManagement servicesManagement, IPagesManagement pagesManagement, ITestimonialsManagement testimonialsManagement, IPostsManagement postsManagement, ICustomersManagement customersManagement, IRoomsManagement roomsManagement, IBooksManagement booksManagement)
        {
            _roomTypesManagement = roomTypesManagement;
            _servicesManagement = servicesManagement;
            _pagesManagement = pagesManagement;
            _testimonialsManagement = testimonialsManagement;
            _postsManagement = postsManagement;
            _customersManagement = customersManagement;
            _roomsManagement = roomsManagement;
            _booksManagement = booksManagement;
        }

        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel
            {
                RoomTypesList = _roomTypesManagement.GetAll().OrderBy(m => m.OrderSort).ToList(), //Get All Room Types
                ServicesList = _servicesManagement.GetAll().OrderBy(m => m.OrderSort).ToList(), //Get All Additional Services
                PostsList = _postsManagement.GetAll().OrderBy(m => m.OrderSort).Take(3).ToList(),
                Page = _pagesManagement.Get(m => m.Name == "About"), //Get About Page
                TestimonialsList = _testimonialsManagement.GetAll(m => m.IsShow == true).OrderBy(m => m.OrderSort).ToList()//Get All Showable Testimonials
                //TestimonialsList = _testimonialsManagement.GetAll(m => m.IsShow == true).Join(, t => t.CustomerID, c => c.ID, (t, c) => new { t, c }).OrderBy(m => m.OrderSort).ToList() //Get All Showable Testimonials

            };

            List<string> CountryList = new List<string>();
            CultureInfo[] CInfoList = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo CInfo in CInfoList)
            {
                RegionInfo R = new RegionInfo(CInfo.LCID);
                if (!(CountryList.Contains(R.EnglishName)))
                {
                    CountryList.Add(R.EnglishName);
                }
            }

            CountryList.Sort();
            ViewBag.CountryList = CountryList;

            return View(model);
        }

        [HttpPost]
        public string NewBooking(HomeViewModel model)
        {
            if (model.Book.ArrivalDate < DateTime.Today)
            {
                return "Arrival Date must be greater than today.";
            }
            else if (model.Book.ArrivalDate >= model.Book.DepartureDate)
            {
                return "Departure Date must be greater than Arrival Date.";
            }

            bool available = false;
            model.Book.BookingDate = DateTime.Now;
            var customer = _customersManagement.Get(c=>c.Nation == model.Customer.Nation && c.NationalID == model.Customer.NationalID);
            var rooms = _roomsManagement.GetAll(r => r.RoomTypeID == model.RoomTypeID).ToList();
            if (customer == null)
            {
                Customers newCustomer = model.Customer;
                if (String.IsNullOrEmpty(customer.Email) || String.IsNullOrEmpty(customer.Name))
                {
                    return "Your E-Mail and/or Name is empty. Try again";
                }
                _customersManagement.Add(newCustomer);
                customer = _customersManagement.Get(c => c.Nation == model.Customer.Nation && c.NationalID == model.Customer.NationalID);
            }

            model.Book.CustomerID = customer.ID;
            
            if (String.IsNullOrEmpty(customer.Name))
            {
                if (!String.IsNullOrEmpty(model.Customer.Name))
                {
                    customer.Name = model.Customer.Name;
                    _customersManagement.Update(customer);
                }
                else
                {
                    return "Your Name is empty.";
                }
            }
            if (String.IsNullOrEmpty(customer.Email))
            {
                if (!String.IsNullOrEmpty(model.Customer.Email))
                {
                    customer.Email = model.Customer.Email;
                    _customersManagement.Update(customer);
                }
                else
                {
                    return "Your E-Mail is empty.";
                }
            }

            foreach (var room in rooms)
            {
                var books = _booksManagement.GetAll(b => b.RoomID == room.ID).ToList();
                foreach (var book in books)
                {
                    available = DateHelper.AvailableDate(model.Book.ArrivalDate, model.Book.DepartureDate, book.ArrivalDate, book.DepartureDate);

                    if (!available)
                    {
                        break;
                    }
                }

                if (available)
                {
                    model.Book.RoomID = room.ID;
                    _booksManagement.Add(model.Book);
                    break;
                }
            }

            return "Your booking has been saved!";
        }
    }
}