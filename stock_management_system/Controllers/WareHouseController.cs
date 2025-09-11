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
    public class WareHouseController : Controller
    {
        WareHouseManager wm = new WareHouseManager(new EfWareHouseDal());
        [CustomAuthorize("admin", "user")]
        public ActionResult Index(int p =1)
        {
            var warehousevalues = wm.GetList().ToPagedList(p, 5);
            return View(warehousevalues);
        }
        [CustomAuthorize("admin")]
        [HttpGet]
        public ActionResult AddWareHouse()
        {
            return View();
        }
        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult AddWareHouse(Warehouse p)
        {
            p.WareHouseStatus = true;
            wm.WarehouseAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult WareHousePartial()
        {
            return PartialView();
        }
        [CustomAuthorize("admin")]
        public ActionResult WareHouseDelete(int id)
        {
            var categoryvalue = wm.GetByID(id);
            categoryvalue.WareHouseStatus = false;
            wm.WarehouseDelete(categoryvalue);
            return RedirectToAction("Index");
        }
        [CustomAuthorize("admin")]
        [HttpGet]
        public ActionResult EditWareHouse(int id)
        {
            var brandvalue = wm.GetByID(id);
            return View(brandvalue);
        }
        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult EditWareHouse(Warehouse p)
        {
            var category = wm.GetByID(p.WareHouseId);
            if (category != null)
            {
                category.WareHouseName = p.WareHouseName;
                category.WareHouseLocation = p.WareHouseLocation;
                category.WareHouseStatus = true; 
                wm.WarehouseUpdate(category);
            }
            return RedirectToAction("Index");
        }
    }
}