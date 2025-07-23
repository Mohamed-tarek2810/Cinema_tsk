using Cinema_task.Data;
using Cinema_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema_task.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CinemaController : Controller
    {
        private readonly ApplicationDbContext _context = new();

        public IActionResult Index()
        {
            var Cinema = _context.Cinemas.Include(e => e.Movies).ToList();
            return View(Cinema);
        }

        [HttpGet]
        public IActionResult Index1()//create page 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index1(Cinemas Cinemas)//create page 
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
        //return RedirectToAction(actionMame: "NotFoundPage", controllertumo: "Home"); 

        [HttpPost]
        public IActionResult Edit(Cinemas Cinemas)
        {
            _context.Update(Cinemas);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete([FromRoute] int id)
        {
            var Cinema = _context.Cinemas.Find(id);

            if (Cinema is not null)
            {
                _context.Remove(Cinema);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

    }
}
