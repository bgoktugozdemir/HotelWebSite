using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using Hotel.Model.DataModel;
using WebProje.Models.Home;

namespace WebProje.Controllers
{
    public class HomeController : Controller
    {
        private IRoomTypesManagement _roomTypesManagement;
        private IServicesManagement _servicesManagement;
        private IPagesManagement _pagesManagement;
        private ITestimonialsManagement _testimonialsManagement;

        public HomeController(IRoomTypesManagement roomTypesManagement, IServicesManagement servicesManagement, IPagesManagement pagesManagement, ITestimonialsManagement testimonialsManagement)
        {
            _roomTypesManagement = roomTypesManagement;
            _servicesManagement = servicesManagement;
            _pagesManagement = pagesManagement;
            _testimonialsManagement = testimonialsManagement;
        }

        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel
            {
                RoomTypesList = _roomTypesManagement.GetAll().OrderBy(m => m.OrderSort).ToList(), //Get All Room Types
                ServicesList = _servicesManagement.GetAll().OrderBy(m => m.OrderSort).ToList(), //Get All Additional Services
                Page = _pagesManagement.Get(m => m.Name== "About"), //Get About Page
                TestimonialsList = _testimonialsManagement.GetAll(m => m.IsShow == true).OrderBy(m => m.OrderSort).ToList() //Get All Showable Testimonials
                //TestimonialsList = _testimonialsManagement.GetAll(m => m.IsShow == true).Join(, t => t.CustomerID, c => c.ID, (t, c) => new { t, c }).OrderBy(m => m.OrderSort).ToList() //Get All Showable Testimonials
            };

            return View(model);
        }
    }
}