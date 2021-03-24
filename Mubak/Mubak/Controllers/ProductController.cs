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
        // GET: ItemProduct
        public ActionResult Index()
        {
            var lst = _ctxProduct.Products.ToList();
            return View(lst);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(_ctxProduct.Categories, "Id", "Description", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, Description, Model, Brand, UnitaryPrice, Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.Category = _ctxProduct.Categories.First(ip => ip.Id == product.Category.Id);
                _ctxProduct.Products.Add(product);
                _ctxProduct.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            var product = _ctxProduct.Products.First(d => d.Id == id);
            ViewBag.CategoryList = new SelectList(_ctxProduct.Categories, "Id", "Description", product.Id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Product, UnitaryValue, Amount, TotalValue")] Product product)
        {
            if (ModelState.IsValid)
            {
                Product productUpdate = _ctxProduct.Products.First(ip => ip.Id == product.Id);
                productUpdate.Category = _ctxProduct.Categories.First(p => p.Id == product.Category.Id);
                productUpdate.Model = product.Model;
                productUpdate.Brand = product.Brand;
                productUpdate.UnitaryPrice = product.UnitaryPrice;
                productUpdate.Description = product.Description;
                _ctxProduct.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Detail(int id)
        {
            return View(_ctxProduct.Products.First(ip => ip.Id == id));
        }

        public ActionResult Delete(int id)
        {
            var product = _ctxProduct.Products.First(ip => ip.Id == id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var product = _ctxProduct.Products.First(ip => ip.Id == id);
            _ctxProduct.Products.Remove(product);
            _ctxProduct.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}