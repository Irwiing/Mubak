using Context;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mubak.Controllers
{
    public class ItemProductController : Controller
    {
        private ItemProductContext _ctxItemProduct = new ItemProductContext();

        // GET: ItemProduct
        public ActionResult Index()
        {
            var lst = _ctxItemProduct.ItemsProducts.ToList();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemProduct itemProduct)
        {
            if(ModelState.IsValid)
            {
                _ctxItemProduct.ItemsProducts.Add(itemProduct);
                _ctxItemProduct.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(itemProduct);
        }

        public ActionResult Edit(int id)
        {
            var itemProduct = _ctxItemProduct.ItemsProducts.First(ip => ip.Id == id);
            return View(itemProduct);
        }

        public ActionResult Edit(ItemProduct itemProduct)
        {
            if(ModelState.IsValid)
            {
                ItemProduct itemProductUpdate = _ctxItemProduct.ItemsProducts.First(ip => ip.Id == itemProduct.Id);
                itemProductUpdate.Product = itemProduct.Product;
                itemProductUpdate.UnitaryValue = itemProduct.UnitaryValue;
                itemProductUpdate.Amount = itemProduct.Amount;
                itemProductUpdate.TotalValue = itemProduct.TotalValue;
                _ctxItemProduct.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(itemProduct);
        }

        public ActionResult Detail(int id)
        {
            return View(_ctxItemProduct.ItemsProducts.First(ip => ip.Id == id));
        }

        public ActionResult Delete(int id)
        {
            var itemProduct = _ctxItemProduct.ItemsProducts.First(ip => ip.Id == id);
            return View(itemProduct);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var itemProduct = _ctxItemProduct.ItemsProducts.First(ip => ip.Id == id);
            _ctxItemProduct.ItemsProducts.Remove(itemProduct);
            _ctxItemProduct.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}