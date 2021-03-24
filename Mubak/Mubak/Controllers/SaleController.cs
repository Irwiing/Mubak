using System.Linq;
using System.Web.Mvc;
using Model;
using Context;

namespace Mubak.Controllers
{
    public class SaleController : Controller
    {
        private SaleContext _ctxSale = new SaleContext();

        // GET: Sale
        public ActionResult Index()
        {
            return View(_ctxSale.Sales.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                _ctxSale.Sales.Add(sale);
                _ctxSale.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sale);
        }

        public ActionResult Edit(int id)
        {
            return View(_ctxSale.Sales.First(s => s.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sale sale)
        {
            if (ModelState.IsValid)
            {
                Sale saleUpdate = _ctxSale.Sales.First(s => s.Id == sale.Id);
                saleUpdate.Items = sale.Items;
                saleUpdate.PaymentType = sale.PaymentType;
                saleUpdate.DateSale = sale.DateSale;
                saleUpdate.Costumer = sale.Costumer;
                saleUpdate.TotalValue = sale.TotalValue;
                _ctxSale.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sale);
        }
        public ActionResult Details(int id)
        {
            return View(_ctxSale.Sales.First(s => s.Id == id));
        }

        public ActionResult Delete(int id)
        {
            return View(_ctxSale.Sales.First(s => s.Id == id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var sale = _ctxSale.Sales.First(s => s.Id == id);
            _ctxSale.Sales.Remove(sale);
            _ctxSale.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}