using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using WebProje.Models.Blog;

namespace WebProje.Controllers
{
    public class BlogController : Controller
    {
        private IPostsManagement _postsManagement;
        private ISettingsManagement _settingsManagement;

        public BlogController(IPostsManagement postsManagement, ISettingsManagement settingsManagement)
        {
            _postsManagement = postsManagement;
            _settingsManagement = settingsManagement;
        }

        // GET: Blog
        public ActionResult Index()
        {
            BlogViewModel model = new BlogViewModel
            {
                PostsList = _postsManagement.GetAll().OrderBy(m => m.OrderSort).ToList(),
                Setting = _settingsManagement.Get(m=>m.Name == "hotel.name")
            };
            return View(model);
        }

        public ActionResult Details(int? id)
        {
            BlogViewModel model = new BlogViewModel
            {
                Post = _postsManagement.Get(m => m.ID == id),
                Setting = _settingsManagement.Get(m => m.Name == "hotel.name")
            };
            return View(model);
        }
    }
}