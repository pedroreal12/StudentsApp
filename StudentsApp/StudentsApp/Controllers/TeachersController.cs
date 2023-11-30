using Microsoft.AspNetCore.Mvc;
using StudentsApp.Models;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System;


namespace StudentsApp.Controllers
{
    public class TeachersController : Controller 
    {

        private readonly ILogger<TeachersController> _logger;
        private readonly SchoolContext _context = new();

        public TeachersController(ILogger<TeachersController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetTeachers() 
        {
            var teachers = (from p in _context.People
                join r in _context.Roles
                on p.FkIdRoles equals r.Id
                where p.FkIdRoles == 1
                select new {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Role = r.StrLabel
                }).ToList();
            var data = JsonSerializer.Serialize(teachers);
            return Json(data);
        }

        //GET Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Person teacher = new()
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    BirthDate = DateTime.Parse(collection["BirthDate"]),
                    FkIdRoles = 1
                };

                // Add the new object to the Orders collection.
                _context.People.Add(teacher);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }
        //GET Edit
        public IActionResult Edit(int Id)
        {
            if (Id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var teacher = _context.People.Find(Id);
            if (teacher == null)
            {
                return NotFound(); 
            }
            return View(teacher);
        }
        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, IFormCollection collection)
        {
            try
            {
                if (Id <= 0)
                {
                    return RedirectToAction(nameof(Index));

                }
                Person teacher = _context.People.Find(Id);
                if (teacher == null)
                {
                    return NotFound();
                }
                teacher.FirstName = collection["FirstName"];
                teacher.LastName = collection["LastName"];
                teacher.BirthDate = DateTime.Parse(collection["BirthDate"]);
                _context.SaveChanges();
                Console.WriteLine("Role edited!");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return View();
            }
        }

        public IActionResult Details(int Id)
        {
            if (Id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var teacher = _context.People.Find(Id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        //GET Delete
        public IActionResult Delete(int Id)
        {
            try
            {
                var teacher = _context.People.Find(Id);
                if (teacher == null)
                {
                    return NotFound();
                }
                _context.People.Remove(teacher);
                _context.SaveChanges();
                Console.WriteLine("Teacher deleted!");
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
