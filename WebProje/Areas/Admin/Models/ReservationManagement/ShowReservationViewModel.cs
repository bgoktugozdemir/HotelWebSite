using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Core.Enum;
using Hotel.Model.DataModel;

namespace WebProje.Areas.Admin.Models.ReservationManagement
{
    public class ShowReservationViewModel
    {
        public List<Books> BookList { get; set; }
        public List<Books> OldBookList { get; set; }
    }
}