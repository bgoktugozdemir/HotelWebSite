using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Model.DataModel;

namespace WebProje.Areas.Admin.Models.Home
{
    public class HomeViewModel
    {
        public List<ContactForms> ContactFormsList { get; set; }
        public List<Books> BooksList { get; set; }
        public int CustomerCount { get; set; }
        public int BookingCount { get; set; }
        public int RoomCount { get; set; }
        public double TotalEarning { get; set; }
        public List<RoomTypes> RoomTypeList { get; set; }
        public ChatViewModel ChatViewModel { get; set; }
    }
}