using Business_Layer.Concreate;
using Data_Access_Layer.entityframework;
using Entity_Layer.Concrete;
using PagedList;
using stock_management_system.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stock_management_system.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        [CustomAuthorize("admin", "user")]
        public ActionResult Index(int p =1)
        {
            var categoryvalues = cm.GetList().ToPagedList(p, 5); 
            return View(categoryvalues);
        }

        [CustomAuthorize("admin")]
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            p.CategoryStatus = true;
            cm.CategoryAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult CategoryPartial()
        {
            return PartialView();
        }
        [CustomAuthorize("admin")]
        public ActionResult CategoryDelete(int id)
        {
            var categoryvalue = cm.GetByID(id);
            categoryvalue.CategoryStatus = false;
            cm.CategoryDelete(categoryvalue);
            return RedirectToAction("Index");
        }
        [CustomAuthorize("admin")]
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var brandvalue = cm.GetByID(id);
            return View(brandvalue);
        }
        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            var category = cm.GetByID(p.CategoryId);
            if (category != null)
            { 
                category.CategoryName = p.CategoryName;
                category.CategoryStatus = true; 
                cm.CategoryUpdate(category);
            }
            return RedirectToAction("Index");
        }
    }
}