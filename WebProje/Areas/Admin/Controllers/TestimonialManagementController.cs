using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using Hotel.Core.Enum;
using Hotel.Model.DataModel;
using WebProje.Areas.Admin.Models.TestimonialManagement;

namespace WebProje.Areas.Admin.Controllers
{
    [Authorize]
    public class TestimonialManagementController : Controller
    {
        private ITestimonialsManagement _testimonialsManagement;
        private IBooksManagement _bookManagement;

        public TestimonialManagementController(ITestimonialsManagement testimonialsManagement, IBooksManagement bookManagement)
        {
            _testimonialsManagement = testimonialsManagement;
            _bookManagement = bookManagement;
        }

        // GET: Admin/TestimonialManagement
        public ActionResult Index()
        {
            ShowTestimonialViewModel model = new ShowTestimonialViewModel
            {
                TestimonialList = _testimonialsManagement.GetAll().OrderBy(t=>t.OrderSort).ToList()
            };
            return View(model);
        }

        public ActionResult NewTestimonial(int? id)
        {
            NewTestimonialViewModel model = new NewTestimonialViewModel()
            {
                BookList = _bookManagement.GetAll().ToList(),
                ShowingStatusList= EnumHelpers.ConvertEnumToList(typeof(ShowStatus))
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