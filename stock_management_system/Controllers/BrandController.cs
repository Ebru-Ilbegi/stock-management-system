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
    public class BrandController : Controller
    {
        BrandManager bm = new BrandManager(new EfBrandDal());

        [CustomAuthorize("admin", "user")]
        public ActionResult Index(int p =1)
        {
            var brandvalues = bm.GetList().ToPagedList(p, 5);
            return View(brandvalues);
        }

        [CustomAuthorize("admin")]
        [HttpGet]
        public ActionResult AddBrand()
        {
            return View();
        }
        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult AddBrand(Brand p)
        {
            p.BrandStatus = true; 
            bm.BrandAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult BrandPartial()
        {
            return PartialView();
        }
        [CustomAuthorize("admin")]
        public ActionResult BrandDelete(int id)
        {
            var brandvalue = bm.GetByID(id);
            brandvalue.BrandStatus = false;
            bm.BrandDelete(brandvalue);
            return RedirectToAction("Index");
        }
        [CustomAuthorize("admin")]
        [HttpGet]
        public ActionResult EditBrand(int id)
        {
            var brandvalue = bm.GetByID(id);
            return View(brandvalue);
        }
        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult EditBrand(Brand p)
        {
            var brand = bm.GetByID(p.BrandId);
            if (brand != null)
            {
                brand.BrandName = p.BrandName;
                brand.BrandStatus = true; 
                bm.BrandUpdate(brand);
            }
            return RedirectToAction("Index");
        }

    }
}