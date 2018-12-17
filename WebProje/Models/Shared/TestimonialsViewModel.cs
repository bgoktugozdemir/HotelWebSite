using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Model.DataModel;

namespace WebProje.Models.Shared
{
    public class TestimonialsViewModel
    {
        public List <Testimonials> TestimonialList { get; set; }
        public List <Customers> CustomersList { get; set; }
    }
}