using CoreAndFood.Data.Models;
using CoreAndFood.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        public IActionResult Index()
        {

            return View(categoryRepository.TList());
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            categoryRepository.TAdd(category);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        public IActionResult CategoryGet(int id)
        {
            var variable = categoryRepository.TGet(id);
            Category ct = new Category()
            {
                CategoryName = variable.CategoryName,
                CategoryDescription = variable.CategoryDescription,
                CategoryID = variable.CategoryID
            };

            return View(ct);
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category c)
        {
            categoryRepository.TUpdate(c);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryDelete(int id)
        {
            var result = categoryRepository.TGet(id);
            result.Status = false;
            categoryRepository.TUpdate(result);
            return RedirectToAction("Index");

        }
    }
}
