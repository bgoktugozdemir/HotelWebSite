using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Core.Enum;
using Hotel.Model.DataModel;

namespace WebProje.Areas.Admin.Models.TestimonialManagement
{
    public class NewTestimonialViewModel
    {
        public Testimonials Testimonial { get; set; }
        public List<Customers> CustomerList { get; set; }
    }
}