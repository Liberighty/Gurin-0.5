using Gurin_0._5.Data;
using Gurin_0._5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gurin_0._5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyAppilcationContext _context;

        public HomeController(ILogger<HomeController> logger, MyAppilcationContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Index(string lastName, string firstName)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(x => x.LastName.Contains(lastName));
            }
            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(x => x.FirstName.Contains(firstName));
            }

            var students = query.ToList();

            return View(students);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var students = _context.Students.ToList();

            return View(students);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string lastName, string firstName)
        {
            var student = new Student
            {
                LastName = lastName,
                FirstName = firstName
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == Id);

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(string lastName, string firstName, int Id)
        {
            
                var student = _context.Students.FirstOrDefault(x => x.Id == Id);
           
                if (student != null)
                { 
                    student.LastName = lastName;
                    student.FirstName = firstName;

            
                
                    _context.Students.Update(student);
                    _context.SaveChanges();
                }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Remove(int Id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == Id);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();

            }
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
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
