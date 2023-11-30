using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentsApp.Controllers
{
    public class CurricularUnitsController : Controller
    {
        // GET: CurricularUnitsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CurricularUnitsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CurricularUnitsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurricularUnitsController/Create
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

        // GET: CurricularUnitsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CurricularUnitsController/Edit/5
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

        // GET: CurricularUnitsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
