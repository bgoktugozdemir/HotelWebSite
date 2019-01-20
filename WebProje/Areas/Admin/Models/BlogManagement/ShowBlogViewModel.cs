using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hotel.Model.DataModel;

namespace WebProje.Areas.Admin.Models.BlogManagement
{
    public class ShowBlogViewModel
    {
        public List<Posts> PostList { get; set; }
    }
}