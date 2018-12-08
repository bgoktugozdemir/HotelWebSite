using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hotel.Model.DataModel;

namespace WebProje.Models.About
{
    public class AboutViewModel
    {
        public List<Services> ServicesList { get; set; }
        public Pages Page { get; set; }
        public List<Testimonials> TestimonialsList { get; set; }
    }
}