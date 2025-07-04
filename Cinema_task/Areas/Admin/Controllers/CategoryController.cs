using Cinema_task.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_task.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context = new();

        [Area("Admin")]
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

       
    }
}
