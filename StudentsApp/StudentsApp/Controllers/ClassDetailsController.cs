using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentsApp.Controllers
{
    public class ClassDetailsController : Controller
    {
        // GET: ClassDetailsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ClassDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClassDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassDetailsController/Create
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

        // GET: ClassDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClassDetailsController/Edit/5
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

        // GET: ClassDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
