using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mubak.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryContext _ctxCategory = new CategoryContext();
        public ActionResult Index()
        {
            var categories = _ctxCategory.Categories.ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                _ctxCategory.Categories.Add(newCategory);
                _ctxCategory.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newCategory);
        }
        public ActionResult Edit(int id)
        {
            var selectedCategory = _ctxCategory.Categories.First(category => category.Id == id);
            return View(selectedCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category updatedCategory)
        {
            if (ModelState.IsValid)
            {
                var selectedCategory = _ctxCategory.Categories.First(category => category.Id == updatedCategory.Id);
                selectedCategory.Description = updatedCategory.Description;
                _ctxCategory.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updatedCategory);
        }

        public ActionResult Details(int id)
        {
            var selectedCategory = _ctxCategory.Categories.First(category => category.Id == id);
            return View(selectedCategory);
        }

        public ActionResult Delete(int id)
        {
            var selectedCategory = _ctxCategory.Categories.First(category => category.Id == id);
            return View(selectedCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var selectedCategory = _ctxCategory.Categories.First(category => category.Id == id);
            _ctxCategory.Categories.Remove(selectedCategory);
            _ctxCategory.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}