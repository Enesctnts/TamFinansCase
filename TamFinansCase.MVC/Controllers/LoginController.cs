using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TamFinansCase.DataAccess.Concrete;
using TamFinansCase.Entites.Concrete;

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
        public ActionResult UserLogin(User model)
        {
            Context context = new Context();
            var userInfo = context.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (userInfo == null)
            {
                return View("UserLogin");
            }

            FormsAuthentication.SetAuthCookie(userInfo.Email, false);
            Session["Email"] = userInfo.Email;
            return RedirectToAction("GetList", "Book");

        }

        public ActionResult LogOut(User model)
        {
            FormsAuthentication.SignOut();
            System.Threading.Thread.Sleep(1000);//Alert mesajı gözükmesi için 1 sn bekle
            return RedirectToAction("UserLogin", "Login");
        }
    }
}