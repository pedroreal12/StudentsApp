using Microsoft.AspNetCore.Mvc;
using StudentsApp.Models;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Http;

namespace StudentsApp.Controllers
{
    public class CurricularUnitsController : Controller
    {
        private readonly SchoolContext _context = new();
        // GET: CurricularUnitsController
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCurricularUnits()
        {
            var CurricularUnits = (from c in _context.CurricularUnits
                select new {
                    Id = c.Id,
                    StrName = c.StrName,
                }).ToList();
            var data = JsonSerializer.Serialize(CurricularUnits);
            return Json(data);
        }

        // GET: CurricularUnitsController/Details/5
        public ActionResult Details(int Id)
        {
            if (Id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var curricular = _context.CurricularUnits.Find(Id);

            if (curricular == null)
            {
                return NotFound();
            }

            return View(curricular);
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
                CurricularUnit curricular = new()
                {
                    StrName = collection["StrName"],
                };

                // Add the new object to the Orders collection.
                _context.CurricularUnits.Add(curricular);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: CurricularUnitsController/Edit/5
        public ActionResult Edit(int Id)
        {
            if (Id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var curricular = _context.CurricularUnits.Find(Id);

            if (curricular == null)
            {
                return NotFound();
            }

            return View(curricular);
        }

        // POST: CurricularUnitsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, IFormCollection collection)
        {
            try
            {
                if (Id <= 0)
                {
                    return RedirectToAction(nameof(Index));

                }
                CurricularUnit curricular = _context.CurricularUnits.Find(Id);
                if (curricular == null)
                {
                    return NotFound();
                }
                curricular.StrName = collection["StrName"];
                _context.SaveChanges();
                Console.WriteLine("Curricular Unit edited!");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return View();
            }
        }

        // GET: CurricularUnitsController/Delete/5
        public ActionResult Delete(int Id)
        {
            try
            {
                var curricular = _context.CurricularUnits.Find(Id);
                if (curricular == null)
                {
                    return NotFound();
                }
                _context.CurricularUnits.Remove(curricular);
                _context.SaveChanges();
                Console.WriteLine("Curricular Unit deleted!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
