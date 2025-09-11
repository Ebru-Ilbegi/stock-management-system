using Data_Access_Layer.Concrete_dal;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace stock_management_system.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();

       
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(User p)
        {
           
            var adminUser = c.Users.FirstOrDefault(x => x.UserMail == p.UserMail
                                                        && x.UserPassword == p.UserPassword
                                                        && x.UserRole.ToLower() == "admin");

            if (adminUser != null)
            {
                FormsAuthentication.SetAuthCookie(adminUser.UserMail, false);
                Session["UserId"] = adminUser.UserId;
                Session["UserName"] = adminUser.UserMail;
                Session["Role"] = adminUser.UserRole;

                return RedirectToAction( "Profile","User");
            }
            else
            {
                TempData["Error"] = "Invalid admin credentials!";
                return RedirectToAction("AdminLogin");
            }
        }

       
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(User p)
        {
            var normalUser = c.Users.FirstOrDefault(x => x.UserMail == p.UserMail
                                          && x.UserPassword == p.UserPassword
                                          && x.UserRole != null
                                          && x.UserRole.ToLower() == "user");


            if (normalUser != null)
            {
                FormsAuthentication.SetAuthCookie(normalUser.UserMail, false);
                Session["UserId"] = normalUser.UserId;
                Session["UserName"] = normalUser.UserMail;
                Session["Role"] = normalUser.UserRole;

                return RedirectToAction( "Profile","User");
            }
            else
            {
                TempData["Error"] = "Invalid user credentials!";
                return RedirectToAction("UserLogin");
            }
        }

       
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }

}
