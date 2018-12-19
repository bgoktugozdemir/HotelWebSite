using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Core.Enum;
using Hotel.Model.DataModel;

namespace WebProje.Areas.Admin.Models.ReservationManagement
{
    public class NewReservationViewModel
    {
        public Books Book { get; set; }
        public List<RoomTypes> RoomTypeList { get; set; }
        public List<Rooms> RoomList { get; set; }
        public List<Customers> CustomerList { get; set; }
    }
}