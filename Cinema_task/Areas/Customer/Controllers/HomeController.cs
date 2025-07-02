using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cinema_task.Models;
using Cinema_task.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema_task.Areas.Customer.Controllers;
[Area("Customer")]
public class HomeController : Controller
{
    private readonly ApplicationDbContext _dbContext = new();

    public IActionResult Index()
    {
        var Movies = _dbContext.Movies.Include(e => e.Cinema).Include(e=>e.Category).ToList();
        if (Movies == null)
        {
            return NotFound();
        }
        return View(Movies);
        //return View();
    }

    public IActionResult Details(int id)
    {
        var Detaiils = _dbContext.Movies.Include(e => e.Cinema).Include(e => e.Category).Include(e => e.ActorMovies).ThenInclude(e=>e.Actors)
            .FirstOrDefault(e=>e.MoviesId==id);
        if (Detaiils == null)
        {
            return NotFound();
        }
        return View(Detaiils);
    }
    public IActionResult Categories()
    {
        var Categories = _dbContext.Categories.Include(e=>e.Movies) .ToList(); 
        return View(Categories);
    }
        public IActionResult Cinema()
    {
        {
            var cinema = _dbContext.Cinemas.Include(e => e.Movies).ToList();
            return View(cinema);
        }
        
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
