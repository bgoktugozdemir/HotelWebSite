using System.Collections.Generic;
using Hotel.Model.DataModel;
using WebProje.Models.Shared;

namespace WebProje.Models.Home
{
    public class HomeViewModel
    {
        public Books Book { get; set; }
        public Customers Customer { get; set; }
        public int RoomTypeID { get; set; }

        public List<RoomTypes> RoomTypesList { get; set; }
        public List<Services> ServicesList { get; set; }
        public Pages Page { get; set; }
        public List<Testimonials> TestimonialsList { get; set; }
        public List<Posts> PostsList { get; set; }
    }
}