using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using Hotel.BI.Repository;
using WebProje.Areas.Admin.Models.BlogManagement;

namespace WebProje.Areas.Admin.Controllers
{
    public class BlogManagementController : Controller
    {
        private IPostsManagement _postsManagement;

        public BlogManagementController(IPostsManagement postsManagement)
        {
            _postsManagement = postsManagement;
        }

        // GET: Admin/BlogManagement
        public ActionResult Index()
        {
            ShowBlogViewModel model = new ShowBlogViewModel();
            model.PostList = _postsManagement.GetAll().OrderByDescending(p => p.CreatedAt).ToList();

            return View(model);
        }

        public ActionResult NewPost(int? id)
        {
            NewBlogViewModel model = new NewBlogViewModel();
            if (id != null)
            {
                model.Post = _postsManagement.Get(p => p.ID == id);
            }

            return View(model);
        }

        [HttpPost]
        public string NewPost(NewBlogViewModel model)
        {
            try
            {
                if (model.Post.ID == 0)
                {
                    model.Post.CreatedAt = DateTime.Now;
                    model.Post.EmployeeID = (User as CustomPrincipal).ID;
                    if (model.Post.Thumbnail == null)
                    {
                        model.Post.Thumbnail = "default.jpg";
                    }
                }

                _postsManagement.AddOrUpdate(model.Post);

                return this.AlertMessage("Post has been saved!", "SUCCESS", "success");
            }
            catch (Exception e)
            {
                return this.AlertMessage($"Post could not be saved! ({e.Message})", "ERROR", "danger");
            }
            /*
            catch (DbEntityValidationException dbValEx)
            {
                var outputLines = new StringBuilder();
                foreach (var eve in dbValEx.EntityValidationErrors)
                {
                    outputLines.AppendFormat("{0}: Entity of type {1} in state {2} has the following validation errors:"
                        , DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.AppendFormat("- Property: {0}, Error: {1}"
                            , ve.PropertyName, ve.ErrorMessage);
                    }
                }

                //Tools.Notify(this, outputLines.ToString(),"error");
                throw new DbEntityValidationException(string.Format("Validation errorsrn{0}"
                    , outputLines.ToString()), dbValEx);
            }
            */
        }
    }
}