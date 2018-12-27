using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Hotel.BI.Interface;
using WebProje.Areas.Admin.Models.Login;

namespace WebProje.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private IUsersManagement _usersManagement;

        public LoginController(IUsersManagement usersManagement)
        {
            _usersManagement = usersManagement;
        }

        // GET: Admin/Login
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            var user = _usersManagement.Get(u => u.Employees.Email == model.Email && u.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "E-Mail or Password is wrong!");
                TempData["Error"] = "This user not found.";

                return RedirectToAction("Index", "Login");
            }
            else
            {
                CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel
                {
                    ID = user.ID,
                    Firstname = user.Employees.Name,
                    Surname = user.Employees.Surname,
                    Mail = user.Employees.Email,
                    Image = user.Employees.Image
                };
                serializeModel.Roles.Add("user");

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                string userData = serializer.Serialize(serializeModel);

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, model.Email, DateTime.Now, DateTime.Now.AddMinutes(120), model.RememberMe, userData);

                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);

                //FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }        
    }
}