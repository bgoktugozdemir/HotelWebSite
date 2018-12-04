using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using WebProje.Models.Home;

namespace WebProje.Controllers
{
    public class HomeController : Controller
    {
        private IEkHizmetYonetim _ekHizmetYonetim;

        public HomeController(IEkHizmetYonetim ekHizmetYonetim)
        {
            _ekHizmetYonetim = ekHizmetYonetim;
        }

        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            
            return View(model);
        }
    }
}