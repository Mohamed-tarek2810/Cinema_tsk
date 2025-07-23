using Cinema_task.Data;
using Cinema_task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema_task.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context = new();

        public IActionResult Index()
        {
            var movies = _context.Movies.Include(e=>e.Category).Include(e=>e.Cinema).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Index1()//create page 
        {
            var Catigories = _context.Categories;
            var Cinema = _context.Cinemas;
            CategoriesAndCinemasVM CategoriesAndCinemasVM = new()
            {
                Categories = Catigories.ToList(),
                Cinemas = Cinema.ToList()
            };

            return View(CategoriesAndCinemasVM);
        }
        [HttpPost]
        public IActionResult Index1(Movies Movies)//create page 
        {

            _context.Add(Movies);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public IActionResult Edit( int MoviesId)
        {
            var Movies = _context.Movies.Find(MoviesId);

            var Catigories = _context.Categories;
            var Cinema = _context.Cinemas;
            CategoriesAndCinemasVM CategoriesAndCinemasVM = new()
            {
                Categories = Catigories.ToList(),
                Cinemas = Cinema.ToList(),
                Movies =Movies
                
            };

            return View(CategoriesAndCinemasVM);
        }
        //return RedirectToAction(actionMame: "NotFoundPage", controllertumo: "Home"); 

        [HttpPost]
        public IActionResult Edit(Movies Movies)
        {
            _context.Update(Movies);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete([FromRoute] int id)
        {
            var Movies = _context.Movies.Find(id);

            if (Movies is not null)
            {
                _context.Remove(Movies);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

    }
}
