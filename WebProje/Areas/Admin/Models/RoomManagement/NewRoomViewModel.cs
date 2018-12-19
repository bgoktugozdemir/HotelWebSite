using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Core.Enum;
using Hotel.Model.DataModel;

namespace WebProje.Areas.Admin.Models.RoomManagement
{
    public class NewRoomViewModel
    {
        public Rooms Room { get; set; }
        public List<RoomTypes> RoomTypeList { get; set; }
    }
}