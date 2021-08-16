using CoreAndFood.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public  IActionResult VisualizeProductResult()
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
    }
}
