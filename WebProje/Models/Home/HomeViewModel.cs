using System.Collections.Generic;
using Hotel.Model.DataModel;
using WebProje.Models.Shared;

namespace WebProje.Models.Home
{
    public class HomeViewModel
    {
        public List<RoomTypes> RoomTypesList { get; set; }
        public List<Services> ServicesList { get; set; }
        public Pages Page { get; set; }
        public List<Testimonials> TestimonialsList { get; set; }
        public List<Posts> PostsList { get; set; }
    }
}