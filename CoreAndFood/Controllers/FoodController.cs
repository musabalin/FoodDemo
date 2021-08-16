using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context c = new Context();

        public IActionResult Index(int page=1)
        {

            return View(foodRepository.TList("Category").ToPagedList(page,3));
        }
        [HttpGet]
        public IActionResult FoodAdd()
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        public IActionResult FoodAdd(Food p)
        {
            foodRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteFood(int id)
        {
            //silme işlemi için bir parametre göndermek gerekiyor 
            //bu parametrede silinecek olan tabloya ait ilgili id propertysi ile eşleştirilmesi gerekiyor  
            foodRepository.TDelete(new Food { FoodID = id });
            return RedirectToAction("Index");

        }
        public IActionResult FoodGet(int id)
        {
            var result = foodRepository.TGet(id);
            Food food = new Food()
            {
                Name = result.Name,
                CategoryID = result.CategoryID,
                Price = result.Price,
                Stock = result.Stock,
                Description = result.Description,
                ImgURL = result.ImgURL
            };
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.v1 = values;
            return View(result);
        }
        public IActionResult FoodUpdate(Food food)
        {
            foodRepository.TUpdate(food);
            return RedirectToAction("Index");
        }
    }
}
