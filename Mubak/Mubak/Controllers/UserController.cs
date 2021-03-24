using System.Linq;
using System.Web.Mvc;
using Model;
using Context;

namespace Mubak.Controllers
{
    public class UserController : Controller
    {
        private UserContext _ctxUser = new UserContext();

        // GET: Sale
        public ActionResult Index()
        {
            return View(_ctxUser.Users.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _ctxUser.Users.Add(user);
                _ctxUser.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            return View(_ctxUser.Users.First(u => u.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                User userUpdate = _ctxUser.Users.First(u => u.Id == user.Id);
                userUpdate.Situation = user.Situation;
                userUpdate.Login = user.Login;
                userUpdate.Password = user.Password;
                userUpdate.CPF = user.CPF;
                userUpdate.Name = user.Name;
                userUpdate.Address = user.Address;
                userUpdate.Phone = user.Phone;
                userUpdate.Permission = user.Permission;
                userUpdate.Email = user.Email;

                _ctxUser.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public ActionResult Details(int id)
        {
            return View(_ctxUser.Users.First(u => u.Id == id));
        }

        public ActionResult Delete(int id)
        {
            return View(_ctxUser.Users.First(u => u.Id == id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var user = _ctxUser.Users.First(u => u.Id == id);
            _ctxUser.Users.Remove(user);
            _ctxUser.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}