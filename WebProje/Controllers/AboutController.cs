using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using WebProje.Models.About;

namespace WebProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        private IServicesManagement _servicesManagement;
        private IPagesManagement _pagesManagement;
        private ITestimonialsManagement _testimonialsManagement;

        public AboutController(IServicesManagement servicesManagement, IPagesManagement pagesManagement, ITestimonialsManagement testimonialsManagement)
        {
            _servicesManagement = servicesManagement;
            _pagesManagement = pagesManagement;
            _testimonialsManagement = testimonialsManagement;
        }

        public ActionResult Index()
        {
            AboutViewModel model = new AboutViewModel
            {
                ServicesList = _servicesManagement.GetAll().OrderBy(m => m.OrderSort).ToList(), //Get All Additional Services
                Page = _pagesManagement.Get(m => m.Name == "About"), //Get About Page
                TestimonialsList = _testimonialsManagement.GetAll(m => m.IsShow == true).OrderBy(m => m.OrderSort).ToList() //Get All Showable Testimonials
            };

            return View(model);
        }
    }
}