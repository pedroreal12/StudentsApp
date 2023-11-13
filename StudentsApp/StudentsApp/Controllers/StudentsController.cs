using Microsoft.AspNetCore.Mvc;
using StudentsApp.Models;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StudentsApp.Controllers
{
    public class StudentsController : Controller
    {
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
            using (var context = new SchoolContext())
            {
                var students = context.People
                    .FromSql($"SELECT * FROM People WHERE fkIdRoles = 1")
                    .ToList();
                var data = JsonSerializer.Serialize(students);
                return Json(data);
            }
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
                /* foreach (StudentsModel student in students)
                {
                    if (int.Parse(collection["Age"]) < 1)
                    {
                        student.FirstName = collection["FirstName"];
                        student.LastName = collection["LastName"];
                        student.Age = int.Parse(collection["Age"]);
                        return View(student);
                    }
                } */
                try
                {
                    using var context = new SchoolContext();
                    context.Database.ExecuteSqlRaw($"INSERT INTO People(FirstName, LastName, BirthDate, fkIdRoles) VALUES ('{collection["FirstName"]}', '{collection["LastName"]}', '{collection["BirthDate"]}', 1)");
                } catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
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