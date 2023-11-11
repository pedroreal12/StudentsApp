using Microsoft.AspNetCore.Mvc;
using StudentsApp.Models;
using System.Diagnostics;
using System.Text.Json;

namespace StudentsApp.Controllers
{
    public class TeachersController : Controller 
    {

        private readonly ILogger<TeachersController> _logger;

        public TeachersController(ILogger<TeachersController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() 
        {
            return View();
        }

        public IActionResult getTeachers() 
        {
            return View();
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
                /* foreach (TeachersModel teacher in teachers)
                {
                    if (int.Parse(collection["Age"]) < 1)
                    {
                        teacher.FirstName = collection["FirstName"];
                        teacher.LastName = collection["LastName"];
                        teacher.Age = int.Parse(collection["Age"]);
                        return View(teacher);
                    }
                } */

                /* teachers.Add(new StudentsModel()
                {
                    Id = teachers.Count + 1,
                    FirstName = collection["FirstName"],
                    LastName = collection["LastName"],
                    Age = int.Parse(collection["Age"]),
                    fkIdRole = 2
                }); */
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
        
    }
}