using Context;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mubak.Controllers
{
    public class ProductController : Controller
    {
        private ProductContext _ctxProduct = new ProductContext();
        public ActionResult Index()
        {
            var products = _ctxProduct.Products.ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                _ctxProduct.Products.Add(newProduct);
                _ctxProduct.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newProduct);
        }
        public ActionResult Edit(int id)
        {
            var selectedProduct = _ctxProduct.Products.First(category => category.Id == id);
            return View(selectedProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product updatedProduct)
        {
            if (ModelState.IsValid)
            {
                var selectedProduct = _ctxProduct.Products.First(category => category.Id == updatedProduct.Id);
                selectedProduct.Description = updatedProduct.Description;
                _ctxProduct.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(updatedProduct);
        }

        public ActionResult Details(int id)
        {
            var selectedProduct = _ctxProduct.Products.First(category => category.Id == id);
            return View(selectedProduct);
        }

        public ActionResult Delete(int id)
        {
            var selectedProduct = _ctxProduct.Products.First(category => category.Id == id);
            return View(selectedProduct);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var selectedProduct = _ctxProduct.Products.First(category => category.Id == id);
            _ctxProduct.Products.Remove(selectedProduct);
            _ctxProduct.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}