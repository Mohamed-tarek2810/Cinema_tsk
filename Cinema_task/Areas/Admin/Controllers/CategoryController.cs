using Cinema_task.Data;
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

     
        public IActionResult Index1()//createpage 
        {   
            return View();
        }


    }
}
