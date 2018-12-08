using System.Collections.Generic;
using Hotel.Model.DataModel;

namespace WebProje.Models.Blog
{
    public class BlogViewModel
    {
        public List<Posts> PostsList { get; set; }
        public Posts Post { get; set; }
        public Settings Setting { get; set; }
    }
}