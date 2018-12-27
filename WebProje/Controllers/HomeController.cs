using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using Hotel.Model.DataModel;
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

        public HomeController(IRoomTypesManagement roomTypesManagement, IServicesManagement servicesManagement, IPagesManagement pagesManagement, ITestimonialsManagement testimonialsManagement, IPostsManagement postsManagement, ICustomersManagement customersManagement)
        {
            _roomTypesManagement = roomTypesManagement;
            _servicesManagement = servicesManagement;
            _pagesManagement = pagesManagement;
            _testimonialsManagement = testimonialsManagement;
            _postsManagement = postsManagement;
            _customersManagement = customersManagement;
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
        public ActionResult NewBooking(HomeViewModel model)
        {
            return RedirectToAction("Index");
        }
    }
}