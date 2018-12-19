using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Core.Enum;
using Hotel.Model.DataModel;

namespace WebProje.Areas.Admin.Models.RoomManagement
{
    public class ShowRoomViewModel
    {
        public List<Rooms> RoomList { get; set; }
    }
}