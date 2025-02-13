using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCard.Controllers
{
    public class OtroController : Controller
    {
        // GET: OtroController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OtroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OtroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OtroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OtroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OtroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OtroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
