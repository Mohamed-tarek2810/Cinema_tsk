using Microsoft.AspNetCore.Mvc;

namespace Cinema_task.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
