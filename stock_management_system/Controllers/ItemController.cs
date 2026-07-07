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
    public class ItemController : Controller
    {
        ItemManager im = new ItemManager(new EfItemDal());

        BrandManager bm = new BrandManager(new EfBrandDal());
        WareHouseManager wm = new WareHouseManager(new EfWareHouseDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        [CustomAuthorize("admin")]
        [HttpGet]
        public JsonResult GetItem(int id)
        {
            var item = im.GetByID(id);

            
            var brands = bm.GetList().Select(b => new SelectListItem
            {
                Text = b.BrandName,
                Value = b.BrandId.ToString()
            }).ToList();

            var warehouses = wm.GetList().Select(w => new SelectListItem
            {
                Text = w.WareHouseName,
                Value = w.WareHouseId.ToString()
            }).ToList();

            var categories = cm.GetList().Select(c => new SelectListItem
            {
                Text = c.CategoryName,
                Value = c.CategoryId.ToString()
            }).ToList();

            return Json(new
            {
                item.ItemId,
                item.ItemName,
                item.Unit_Price,
                item.Stock,
                item.BrandId,
                item.WareHouseId,
                item.CategoryId,
                BrandListHtml = string.Join("", brands.Select(b => $"<option value='{b.Value}'>{b.Text}</option>")),
                WareHouseListHtml = string.Join("", warehouses.Select(w => $"<option value='{w.Value}'>{w.Text}</option>")),
                CategoryListHtml = string.Join("", categories.Select(c => $"<option value='{c.Value}'>{c.Text}</option>"))
            }, JsonRequestBehavior.AllowGet);
        }

        [CustomAuthorize("admin", "user")]

        public ActionResult Index(int p=1)
        {
            var itemvalues = im.GetList().ToPagedList(p, 20);
            return View(itemvalues);
        }

        [CustomAuthorize("admin")]
        [HttpGet]
        public ActionResult AddItem()
        {
           
            List<SelectListItem> brandList = (from x in bm.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.BrandName,
                                                  Value = x.BrandId.ToString()
                                              }).ToList();
            ViewBag.brandList = brandList;

            
            List<SelectListItem> warehouseList = (from x in wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WareHouseName,
                                                      Value = x.WareHouseId.ToString()
                                                  }).ToList();
            ViewBag.warehouseList = warehouseList;

            List<SelectListItem> categoryList = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.categoryList = categoryList;


            return View();

        }
        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult AddItem(Item p)
        {
            p.ItemStatus = true;
            im.ItemAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult ItemPartial()
        {
            return PartialView();
        }
        [CustomAuthorize("admin")]
        public ActionResult ItemDelete(int id)
        {
            var itemvalue = im.GetByID(id);
            itemvalue.ItemStatus = false;
            im.ItemDelete(itemvalue);
            return RedirectToAction("Index");
        }
        [CustomAuthorize("admin")]
        [HttpGet]
        public ActionResult EditItem(int id)
        {
            var itemvalue = im.GetByID(id);
            return View(itemvalue);
        }
        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult EditItem(Item p)
        {
            var category = im.GetByID(p.ItemId);
            if (category != null)
            {
                category.ItemName = p.ItemName;
                category.Unit_Price = p.Unit_Price;
                category.Stock = p.Stock;
                category.BrandId = p.BrandId;
                category.CategoryId = p.CategoryId;
                category.WareHouseId = p.WareHouseId;
                category.ItemStatus = true;
                im.ItemUpdate(category);
            }
            return RedirectToAction("Index");
        }

        [CustomAuthorize("admin", "user")]
        public ActionResult SearchBar(int p = 1, string search = null)
        {
            ViewBag.CurrentSearch = search;

            if (string.IsNullOrEmpty(search))
            {
                // Arama boşsa sadece aktif ürünleri getir
                var itemvalues = im.GetListByFilter(x => x.ItemStatus == true).ToPagedList(p, 20);
                return View("Index", itemvalues);
            }

            // Hem aktif ürünleri (Status == true) hem de aranan kelimeyi (ItemName) filtrele
            var filtereditems = im.GetListByFilter(x => x.ItemStatus == true && x.ItemName.Contains(search))
                                  .ToPagedList(p, 20);

            return View("Index", filtereditems);
        }
    }
}