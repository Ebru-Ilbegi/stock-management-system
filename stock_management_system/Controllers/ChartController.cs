using Data_Access_Layer.Concrete_dal;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace stock_management_system.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        private Context db = new Context();

       

        public ActionResult CategoryPieChart()
        {
            var data = db.Items
                         .GroupBy(i => i.Category.CategoryName)
                         .Select(g => new
                         {
                             Name = g.Key,
                             Count = g.Count()
                         })
                         .ToList();

            
            ViewBag.CategoryDataJson = System.Web.Helpers.Json.Encode(data);
            return View();
        }

        public ActionResult WarehouseStackedChart()
        {
            
            var data = db.Items
                         .GroupBy(i => new { i.Warehouse.WareHouseName, i.Category.CategoryName })
                         .Select(g => new
                         {
                             Warehouse = g.Key.WareHouseName,
                             Category = g.Key.CategoryName,
                             Stock = g.Sum(x => x.Stock)
                         })
                         .ToList();

           
            var warehouses = data.Select(d => d.Warehouse).Distinct().ToList();
            var categories = data.Select(d => d.Category).Distinct().ToList();

           
            var chartData = new List<object>();
          
            var header = new List<string> { "Warehouse" };
            header.AddRange(categories);
            chartData.Add(header);

            
            foreach (var w in warehouses)
            {
                var row = new List<object> { w };
                foreach (var c in categories)
                {
                    var stock = data.FirstOrDefault(d => d.Warehouse == w && d.Category == c)?.Stock ?? 0;
                    row.Add(stock);
                }
                chartData.Add(row);
            }

           
            ViewBag.StackedChartData = System.Web.Helpers.Json.Encode(chartData);
            return View();
        }


    }

}