using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using WebProje.Models.Gallery;

namespace WebProje.Controllers
{
    public class GalleryController : Controller
    {
        private IImagesManagement _imagesManagement;
        
        public GalleryController(IImagesManagement imagesManagement)
        {
            _imagesManagement = imagesManagement;
        }

        // GET: Gallery
        public ActionResult Index()
        {
            GalleryViewModel model = new GalleryViewModel
            {
                ImagesList = _imagesManagement.GetAll().OrderBy(m => m.OrderSort).ToList()
            };

            return View(model);
        }
    }
}