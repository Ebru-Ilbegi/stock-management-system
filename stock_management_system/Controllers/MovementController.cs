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
    public class MovementController : Controller
    {
        MovementManager mm = new MovementManager(new EfMovementDal());
        WareHouseManager wm = new WareHouseManager(new EfWareHouseDal());
        ItemManager im = new ItemManager(new EfItemDal());

        [CustomAuthorize("admin")]
        [HttpGet]
        public JsonResult GetMovement(int id)
        {
            var movement = mm.GetByID(id);

            var itemList = im.GetList().Select(x => new SelectListItem
            {
                Text = x.ItemName,
                Value = x.ItemId.ToString()
            }).ToList();

            var warehouseList = wm.GetList().Select(x => new SelectListItem
            {
                Text = x.WareHouseName,
                Value = x.WareHouseId.ToString()
            }).ToList();

            return Json(new
            {
                movement.MovementId,
                movement.ItemId,
                movement.WareHouseId,
                movement.Transaction_Type,
                movement.Amount,
                movement.Date,
                movement.Destination,
                ItemListHtml = string.Join("", itemList.Select(i => $"<option value='{i.Value}'>{i.Text}</option>")),
                WareHouseListHtml = string.Join("", warehouseList.Select(w => $"<option value='{w.Value}'>{w.Text}</option>"))
            }, JsonRequestBehavior.AllowGet);
        }
        [CustomAuthorize("admin", "user")]
        public ActionResult Index(int p =1)
        {
            var movementvalues = mm.GetList().ToPagedList(p, 15);
            return View(movementvalues);
        }
        [CustomAuthorize("admin")]
        [HttpGet]
        public ActionResult AddMovement()
        {

            List<SelectListItem> warehouseList = (from x in wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WareHouseName,
                                                      Value = x.WareHouseId.ToString()
                                                  }).ToList();
            ViewBag.warehouseList = warehouseList;

            List<SelectListItem> itemList = (from x in im.GetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.ItemName,
                                                 Value = x.ItemId.ToString()
                                             }).ToList();
            ViewBag.itemList = itemList;



            return View();

        }

        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult AddMovement(Movement p)
        {
            if (p.Amount <= 0)
            {
                TempData["Error"] = "Amount must be greater tan zero.";
                return RedirectToAction("Index");
            }

            // 1) Hareketi kaydet
            p.MovementStatus = true;
            mm.MovementAdd(p);

            // 2) Item kontrol
            var selectedItem = im.GetByID(p.ItemId);
            if (selectedItem == null)
            {
                TempData["Error"] = "The selected product could not be found.";
                return RedirectToAction("Index");
            }

            if (selectedItem.WareHouseId == p.WareHouseId)
            {
                if (p.Transaction_Type == "Entry")
                {
                    selectedItem.Stock += p.Amount;
                }
                else if (p.Transaction_Type == "Exit")
                {
                    if (selectedItem.Stock < p.Amount)
                    {
                        TempData["Error"] = "Not enough stock.";
                        return RedirectToAction("Index");
                    }
                    selectedItem.Stock -= p.Amount;
                }

                im.ItemUpdate(selectedItem);
            }
            else
            {
                var targetItem = im.GetList().FirstOrDefault(i =>
                    i.WareHouseId == p.WareHouseId &&
                    i.ItemName == selectedItem.ItemName &&
                    i.BrandId == selectedItem.BrandId &&
                    i.CategoryId == selectedItem.CategoryId);

                if (targetItem == null)
                {
                    if (p.Transaction_Type == "Entry")
                    {
                        var newItem = new Item
                        {
                            ItemName = selectedItem.ItemName,
                            Unit_Price = selectedItem.Unit_Price,
                            Stock = p.Amount,
                            WareHouseId = p.WareHouseId,
                            BrandId = selectedItem.BrandId,
                            CategoryId = selectedItem.CategoryId,
                            ItemStatus = true
                        };
                        im.ItemAdd(newItem);
                    }
                    else
                    {
                        TempData["Error"] = "There are no items in this warehouse.";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    if (p.Transaction_Type == "Entry")
                    {
                        targetItem.Stock += p.Amount;
                    }
                    else
                    {
                        if (targetItem.Stock < p.Amount)
                        {
                            TempData["Error"] = "not enough stock.";
                            return RedirectToAction("Index");
                        }
                        targetItem.Stock -= p.Amount;
                    }
                    im.ItemUpdate(targetItem);
                }
            }

            TempData["Success"] = "movement added and stock updated.";
            return RedirectToAction("Index");
        }



        public PartialViewResult MovementPartial()
        {
            return PartialView();
        }
        [CustomAuthorize("admin")]
        public ActionResult MovementDelete(int id)
        {
            var movementvalue = mm.GetByID(id);
            movementvalue.MovementStatus = false;
            mm.MovementDelete(movementvalue);
            return RedirectToAction("Index");
        }
        [CustomAuthorize("admin")]
        [HttpGet]
        public ActionResult EditMovement(int id)
        {

            var movement = mm.GetByID(id);

            // Dropdown listeleri doldur
            ViewBag.itemList = im.GetList().Select(i => new SelectListItem
            {
                Text = i.ItemName,
                Value = i.ItemId.ToString(),
                Selected = (i.ItemId == movement.ItemId)
            }).ToList();

            ViewBag.warehouseList = wm.GetList().Select(w => new SelectListItem
            {
                Text = w.WareHouseName,
                Value = w.WareHouseId.ToString(),
                Selected = (w.WareHouseId == movement.WareHouseId)
            }).ToList();

            return View(movement);
            
        }
        [CustomAuthorize("admin")]
        [HttpPost]
        public ActionResult EditMovement(Movement p)
        {
            var movement = mm.GetByID(p.MovementId);
            if (movement != null)
            {
                movement.ItemId = p.ItemId;
                movement.WareHouseId = p.WareHouseId;
                movement.Transaction_Type = p.Transaction_Type;
                movement.Amount = p.Amount;
                movement.Date = p.Date;
                movement.Destination = p.Destination;
                movement.MovementStatus = true;
                mm.MovementUpdate(movement);
            }
            return RedirectToAction("Index");
        }

    }
}