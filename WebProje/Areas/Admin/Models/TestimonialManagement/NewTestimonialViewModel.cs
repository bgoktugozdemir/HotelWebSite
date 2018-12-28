using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Core.Enum;
using Hotel.Model.DataModel;

namespace WebProje.Areas.Admin.Models.TestimonialManagement
{
    public class NewTestimonialViewModel
    {
        public Testimonials Testimonial { get; set; }
        public List<Books> BookList { get; set; }
        public List<EnumHelpers> ShowingStatusList { get; set; }
        public int ShowingStatus { get; set; }
    }
}