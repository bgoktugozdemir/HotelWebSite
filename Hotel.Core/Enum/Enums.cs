using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Enum
{
    public enum Genders
    {
        [Description("M")]
        [Display(Name = "Male")]
        Male = 1,
        [Description("F")]
        [Display(Name = "Female")]
        Female = 2,
    }
}
