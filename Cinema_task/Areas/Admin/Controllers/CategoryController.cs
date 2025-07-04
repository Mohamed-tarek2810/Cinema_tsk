using Cinema_task.Data;
using Cinema_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema_task.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context = new();

        public IActionResult Index()
        {
            var categories = _context.Categories.Include(e => e.Movies).ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Index1()//create page 
        {   
            return View();
        }
        [HttpPost]
        public IActionResult Index1(Categories Categories)//create page 
        {

            _context.Add(Categories);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
            
        }
        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var Categories = _context.Categories.Find(id);

            return View(Categories);
        }
        //return RedirectToAction(actionMame: "NotFoundPage", controllertumo: "Home"); 
        
        [HttpPost]
        public IActionResult Edit(Categories Categories)
        {
            _context.Update(Categories);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete([FromRoute] int id)
        {
            var Categories = _context.Categories.Find(id);

            if (Categories is not null)
            {
                _context.Remove(Categories);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

    }
}
