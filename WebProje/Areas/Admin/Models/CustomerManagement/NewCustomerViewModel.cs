using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Core.Enum;
using Hotel.Model.DataModel;

namespace WebProje.Areas.Admin.Models.CustomerManagement
{
    public class NewCustomerViewModel
    {
        public Customers Customer { get; set; }
        public List<EnumHelpers> GenderList { get; set; }
    }
}