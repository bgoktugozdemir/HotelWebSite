using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using Hotel.Model.DataModel;
using WebProje.Areas.Admin.Models.TestimonialManagement;

namespace WebProje.Areas.Admin.Controllers
{
    public class TestimonialManagementController : Controller
    {
        private ITestimonialsManagement _testimonialsManagement;
        private ICustomersManagement _customersManagement;

        public TestimonialManagementController(ITestimonialsManagement testimonialsManagement, ICustomersManagement customersManagement)
        {
            _testimonialsManagement = testimonialsManagement;
            _customersManagement = customersManagement;
        }

        // GET: Admin/TestimonialManagement
        public ActionResult Index()
        {
            ShowTestimonialViewModel model = new ShowTestimonialViewModel
            {
                TestimonialList = _testimonialsManagement.GetAll().OrderBy(t=>t.OrderSort).ToList()
            };
            return View();
        }

        public ActionResult NewTestimonialn(int? id)
        {
            NewTestimonialViewModel model = new NewTestimonialViewModel()
            {
                CustomerList = _customersManagement.GetAll().ToList()
            };

            if (id == null)
            {
                model.Testimonial = new Testimonials();
            }
            else
            {
                model.Testimonial = _testimonialsManagement.Get(d => d.ID == id);
            }

            return View(model);
        }
    }
}