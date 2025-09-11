using Business_Layer.Concreate;
using Data_Access_Layer.Concrete_dal;
using Data_Access_Layer.entityframework;
using Entity_Layer.Concrete;
using PagedList;
using PagedList.Mvc;
using stock_management_system.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stock_management_system.Controllers
{
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());

        Context c = new Context();
        [CustomAuthorize("admin", "user")]
        public ActionResult Index(int p = 1)
        {

            var uservalues = um.GetList().ToPagedList(p,20);
            return View(uservalues);
        }
        [CustomAuthorize("admin")]
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult AddUser(User p)
        {
            p.UserStatus = true;
            um.UserAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult UserPartial()
        {
            return PartialView();
        }
        [CustomAuthorize("admin")]
        public ActionResult UserDelete(int id)
        {
            var uservalue = um.GetByID(id);
            uservalue.UserStatus = false;
            um.UserDelete(uservalue);
            return RedirectToAction("Index");
        }
        [CustomAuthorize("admin")]
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            List<SelectListItem> valueuser = (from x in um.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.UserName,
                                                  Value = x.UserId.ToString()
                                              }).ToList();
            ViewBag.vlc = valueuser;

            var uservalue = um.GetByID(id);
            return View(uservalue);
        }
        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult EditUser(User p)
        {
            var user = um.GetByID(p.UserId); 
            if (user != null)
            {
                user.UserName = p.UserName;
                user.UserRole = p.UserRole;
                user.UserPassword = p.UserPassword;
                user.UserMail = p.UserMail;
                um.UserUpdate(user);
            }
            return RedirectToAction("Index");
        }
        
        [HttpGet]
            public ActionResult Profile()
            {
                if (Session["UserId"] == null)
                {
                    
                    return RedirectToAction("Index", "Home");
                }

                int userId = Convert.ToInt32(Session["UserId"]);
                var user = c.Users.FirstOrDefault(x => x.UserId == userId);

                if (user == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(user); 
            
        }
    }
}
