using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TamFinansCase.DataAccess.Concrete;

namespace TamFinansCase.MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login

        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(string email, string password)
        {
            Context context = new Context();
            var userInfo = context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (userInfo != null)
            {
                FormsAuthentication.SetAuthCookie(userInfo.Email, false);
                Session["Email"] = userInfo.Email;
                return RedirectToAction("GetList", "Book");

            }
            else
            {
                return View("UserLogin");

            }
        }
    }
}