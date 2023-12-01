using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsApp.Models;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System;

namespace StudentsApp.Controllers
{
    public class ClassesController : Controller
    {
        private readonly SchoolContext _context = new();
        // GET: ClassesController
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetClasses()
        {
            var classes = (from c in _context.Classes
                    join cd in _context.ClassDetails
                    on c.FkIdClassDetails equals cd.Id  
                    join p in _context.People
                    on c.FkIdPerson equals p.Id
                    where p.FkIdRoles == 2
                    select new {
                    Id = c.Id,
                    classDetailName = cd.StrName,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    }).ToList();
            var data = JsonSerializer.Serialize(classes);
            Console.WriteLine(data);
            return Json(data);
        }

        public JsonResult GetClassById(int Id)
        {
            try
            {
                var nclass = (from c in _context.Classes
                        join cd in _context.ClassDetails
                        on c.FkIdClassDetails equals cd.Id  
                        join p in _context.People
                        on c.FkIdPerson equals p.Id
                        where p.FkIdRoles == 2 && c.Id == Id
                        select new {
                        Id = c.Id,
                        classDetailName = cd.StrName,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        }).ToList();
                var data = JsonSerializer.Serialize(nclass);
                return Json(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json("");
            }
        }

        // GET: ClassesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClassesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Class nclass = new()
                {
                    FkIdPerson = int.Parse(collection["FkIdPerson"]),
                    FkIdClassDetails = int.Parse(collection["FkIdClassDetails"]),
                };

                // Add the new object to the Orders collection.
                _context.Classes.Add(nclass);
                _context.SaveChanges();
                Console.WriteLine("Class created");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ClassesController/Edit/5
        public ActionResult Edit(int Id)
        {
            if (Id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            Class nclass = _context.Classes.Find(Id);

            if (nclass == null)
            {
                return NotFound(); 
            }
            return View(nclass);
        }

        // POST: ClassesController/Edit/5
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
                Class nclass = _context.Classes.Find(Id);
                if (nclass == null)
                {
                    return NotFound();
                }
                nclass.FkIdPerson = int.Parse(collection["FkIdPerson"]);
                nclass.FkIdClassDetails = int.Parse(collection["FkIdClassDetails"]);
                _context.SaveChanges();
                Console.WriteLine("Class edited!");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return RedirectToAction(nameof(Index)); 
            }
        }

        // GET: ClassesController/Delete/5
        public ActionResult Delete(int Id)
        {
            try
            {
                Class nclass = _context.Classes.Find(Id);
                if (nclass == null)
                {
                    return NotFound();
                }
                _context.Classes.Remove(nclass);
                _context.SaveChanges();
                Console.WriteLine("Class deleted!");
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
