using Microsoft.AspNetCore.Mvc;
using StudentsApp.Models;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Linq;
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
            var students = _context.People
                .Where(students => students.FkIdRoles == 2)
                .ToList();
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
                    FkIdRoles = 1
                };

                // Add the new object to the Orders collection.
                //_context.People.InsertOnSubmit(student);

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
            return View();
        }
        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, IFormCollection collection)
        {
            return View();
        }

        public IActionResult Details(int Id)
        {
            return View();
        }

        //GET Delete
        public IActionResult Delete()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}