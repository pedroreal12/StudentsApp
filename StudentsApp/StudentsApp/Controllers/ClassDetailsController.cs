using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsApp.Models;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System;

namespace StudentsApp.Controllers
{
    public class ClassDetailsController : Controller
    {
        private readonly SchoolContext _context = new();
        // GET: ClassDetailsController
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetClassDetails()
        {
            var classDetails = (from c in _context.ClassDetails
                join p in _context.People
                on c.FkIdPerson equals p.Id
                where p.FkIdRoles == 1
                select new {
                    Id = c.Id,
                    classDetailName = c.StrName,
                    classDetailYear = c.StrYear,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                }).ToList();
            var data = JsonSerializer.Serialize(classDetails);
            Console.WriteLine(data);
            return Json(data);
        }

        public JsonResult GetClassDetailsById(int Id)
        {
            var classDetails = (from c in _context.ClassDetails
                    join p in _context.People
                    on c.FkIdPerson equals p.Id
                    where p.FkIdRoles == 1 && c.Id == Id
                    select new {
                    Id = c.Id,
                    classDetailName = c.StrName,
                    classDetailYear = c.StrYear,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    }).ToList();
            var data = JsonSerializer.Serialize(classDetails);
            Console.WriteLine(data);
            return Json(data);
        }
        // GET: ClassDetailsController/Details/5
        public ActionResult Details(int Id)
        {
            if (Id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var classDetail = (from c in _context.ClassDetails
                join p in _context.People
                on c.FkIdPerson equals p.Id
                where c.Id == Id
                select new {
                    Id = c.Id,
                    classDetailName = c.StrName,
                    classDetailYear = c.StrYear,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                }).FirstOrDefault();

            if (classDetail == null)
            {
                return NotFound();
            }

            return View(/*classDetail*/);
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
                ClassDetail classDetail = new()
                {
                    StrName = collection["StrName"],
                    StrYear = collection["StrYear"],
                    FkIdPerson = int.Parse(collection["FkIdPerson"]),
                };

                // Add the new object to the Orders collection.
                Console.WriteLine(classDetail);
                _context.ClassDetails.Add(classDetail);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return RedirectToAction(nameof(Create));
            }
        }
        // GET: ClassDetailsController/Edit/5
        public ActionResult Edit(int Id)
        {
            if (Id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var classDetail = _context.ClassDetails.Find(Id);
            if (classDetail == null)
            {
                return NotFound(); 
            }
            return View(classDetail);
        }

        // POST: ClassDetailsController/Edit/5
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
                ClassDetail classDetail = _context.ClassDetails.Find(Id);
                if (classDetail == null)
                {
                    return NotFound();
                }
                classDetail.StrName = collection["StrName"];
                classDetail.FkIdPerson = int.Parse(collection["FkIdPerson"]);
                classDetail.StrYear = collection["StrYear"];
                _context.SaveChanges();
                Console.WriteLine("Class Detail edited!");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return View();
            }
        }

        // GET: ClassDetailsController/Delete/5
        public ActionResult Delete(int Id)
        {
            try
            {
                ClassDetail classDetail = _context.ClassDetails.Find(Id);
                if (classDetail == null)
                {
                    return NotFound();
                }
                _context.ClassDetails.Remove(classDetail);
                _context.SaveChanges();
                Console.WriteLine("Class Detail deleted!");
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
