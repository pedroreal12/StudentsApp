using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsApp.Models;
using System.Text.Json;

namespace StudentsApp.Controllers
{
    public class RolesController : Controller
    {
        private readonly ILogger<RolesController> _logger;
        private readonly SchoolContext _context = new();

        public RolesController(ILogger<RolesController> logger)
        {
            _logger = logger;
        }
        // GET: RolesController
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetRoles()
        {
            var roles = _context.Roles
                .Select(r => new {r.Id, r.StrLabel, r.StrDescription})
                .ToList();
            var data = JsonSerializer.Serialize(roles);
            Console.WriteLine(data);
            return Json(data);
        }

        // GET: RolesController/Details/5
        public ActionResult Details(int Id)
        {
            var role = _context.Roles.Find(Id);

            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Role role = new()
                {
                    StrLabel = collection["strLabel"],
                    StrDescription = collection["strDescription"],
                };

                // Add the new object to the Orders collection.
                _context.Roles.Add(role);
                _context.SaveChanges();
                Console.WriteLine("Role created");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: RolesController/Edit/5
        public ActionResult Edit(int Id)
        {

            var role = _context.Roles.Find(Id);
            if (role == null)
            {
                return NotFound(); 
            }
            return View(role);
        }

        // POST: RolesController/Edit/5
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
                Role role = _context.Roles.Find(Id);
                if (role == null)
                {
                    return NotFound();
                }
                role.StrLabel = collection["StrLabel"];
                role.StrDescription = collection["StrDescription"];
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

        // GET: RolesController/Delete/5
        public ActionResult Delete(int Id)
        {
            try
            {
                var role = _context.Roles.Find(Id);
                if (role == null)
                {
                    return NotFound();
                }
                _context.Roles.Remove(role);
                _context.SaveChanges();
                Console.WriteLine("Role deleted!");
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
