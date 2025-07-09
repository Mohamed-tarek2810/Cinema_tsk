using Cinema_task.Data;
using Cinema_task.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_task.Areas.Admin.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ApplicationDbContext _context = new();
        [Area("Admin")]
        public IActionResult Index()
        {
            var Cinemas = _context.Cinemas.ToList();
            return View(Cinemas);
        }
        [HttpGet]
        public IActionResult Index1()//Create
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index1(Cinemas Cinemas)//Create
        {

            _context.Add(Cinemas);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var Cinemas = _context.Cinemas.Find(id);

            return View(Cinemas);
        }
    }
}
