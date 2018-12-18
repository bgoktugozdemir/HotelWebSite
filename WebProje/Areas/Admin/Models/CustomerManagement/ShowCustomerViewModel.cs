using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Core.Enum;
using Hotel.Model.DataModel;

namespace WebProje.Areas.Admin.Models.CustomerManagement
{
    public class ShowCustomerViewModel
    {
        public List<Customers> CustomerList { get; set; }
    }
}