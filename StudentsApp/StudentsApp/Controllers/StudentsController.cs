using Microsoft.AspNetCore.Mvc;
using StudentsApp.Models;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System;

namespace StudentsApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context = new();
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]   
        public JsonResult GetStudents()
        {
            var students = (from p in _context.People
                join r in _context.Roles 
                on p.FkIdRoles equals r.Id
                where p.FkIdRoles == 2
                select new {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    BirthDate = p.BirthDate,
                    Role = r.StrLabel
                }).ToList();
            var data = JsonSerializer.Serialize(students);
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
                Person student = new()
                {
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    BirthDate = DateTime.Parse(collection["BirthDate"]),
                    FkIdRoles = 2
                };

                // Add the new object to the Orders collection.
                _context.People.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return View();
            }
        }
        //GET Edit
        public IActionResult Edit(int Id)
        {
            if (Id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            Person student = _context.People.Find(Id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, IFormCollection collection)
        {
            if (Id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            Person student = _context.People.Find(Id);
            if (student == null)
            {
                return NotFound(); 
            }
            return View(student);
        }

        public IActionResult Details(int Id)
        {
            if (Id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            Person student = _context.People.Find(Id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        //GET Delete
        public IActionResult Delete(int Id)
        {
            if (Id <= 0)
            {
                return NotFound();
            } else {

                Person student = _context.People.Find(Id);
                if (student == null)
                {
                    return NotFound();
                }
                _context.People.Remove(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
