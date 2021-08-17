using CoreAndFood.Data;
using CoreAndFood.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname = "Computer",
                stock = 15
            });
            cs.Add(new Class1()
            {
                proname = "LCD",
                stock = 22
            });
            cs.Add(new Class1()
            {
                proname = "Keyboard",
                stock = 113
            });
            return cs;
        }
        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }
        public List<chartclass> FoodList()
        {
            List<chartclass> chartclasses = new List<chartclass>();
            using (var c = new Context())
            {
                chartclasses = c.Foods.Select(x => new chartclass
                { foodName = x.Name, stock = x.Stock }).ToList();
            }
            return chartclasses;
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Statistics()
        {
            var FoodID = c.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryID).FirstOrDefault();

            var result = c.Foods.Count();
            ViewBag.r1 = result;

            var result2 = c.Categories.Count();
            ViewBag.r2 = result2;

            var result3 = c.Foods.Where(x => x.CategoryID == 1).Count();
            ViewBag.r3 = result3;

            var result4 = c.Foods.Where(x => x.CategoryID == 2).Count();
            ViewBag.r4 = result4;

            var result5 = c.Foods.Sum(x => x.Stock);
            ViewBag.r5 = result5;

            var result6 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(y => y.CategoryName == "Legumes").Select(z => z.CategoryID).FirstOrDefault()).Count();
            ViewBag.r6 = result6;

            var result7 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            var result7_1 = c.Foods.OrderByDescending(x => x.Stock).Select(y => y.Stock).FirstOrDefault();
            ViewBag.r7_1 = result7_1;
            ViewBag.r7 = result7;

            var result8_1 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Stock).FirstOrDefault();
            var result8 = c.Foods.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.r8_1 = result8_1;
            ViewBag.r8 = result8;

            var result9 = c.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.r9 = result9;

            var result10 = c.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryID).FirstOrDefault();
            var result10_1 = c.Foods.Where(x => x.CategoryID == result10).Sum(y => y.Stock);
            ViewBag.r10 = result10_1;

            var result11 = c.Categories.Where(x => x.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault();
            var result11_1 = c.Foods.Where(x => x.CategoryID == result11).Sum(y => y.Stock);
            ViewBag.r11 = result11_1;

            var result12 = c.Foods.OrderByDescending(x => x.Price).Select(y => y.Name).FirstOrDefault();
            var result12_1 = c.Foods.OrderByDescending(x => x.Price).Select(y=>y.Price).FirstOrDefault();
            ViewBag.r12 = result12;
            ViewBag.r12_1 = result12_1;
            return View();
        }
    }
}
