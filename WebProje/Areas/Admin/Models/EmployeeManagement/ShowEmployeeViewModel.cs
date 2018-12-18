using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Core.Enum;
using Hotel.Model.DataModel;

namespace WebProje.Areas.Admin.Models.EmployeeManagement
{
    public class ShowEmployeeViewModel
    {
        public List<Employees> EmployeeList { get; set; }
    }
}