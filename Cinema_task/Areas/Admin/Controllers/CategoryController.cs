using Cinema_task.Data;
using Cinema_task.Models;
using Cinema_task.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cinema_task.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private Repositories<Categories> _CategoriesRepository = new();

        
        public async Task<IActionResult> Index()
        {
            var categories = await _CategoriesRepository.GetAsync(
                includes: new Expression<Func<Categories, object>>[] { c => c.Movies }
            );
            return View(categories);
        }

        [HttpGet]
        public IActionResult Index1()
        {
            return View();
        }

   
        [HttpPost]
        public async Task<IActionResult> Index1(Categories category)
        {
            await _CategoriesRepository.CreateAsync(category);
            await _CategoriesRepository.CommitAsync();

            return RedirectToAction(nameof(Index));
        }

     
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int id)
        {
            var category = await _CategoriesRepository.GetOneAsync(c => c.CategoriesId == id);
           

            if (category is null)
                return NotFound();

            return View(category);
        }

    
        [HttpPost]
        public async Task<IActionResult> Edit(Categories category)
        {
            _CategoriesRepository.Edit(category);
            await _CategoriesRepository.CommitAsync();

            return RedirectToAction(nameof(Index));
        }

    
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var category = await _CategoriesRepository.GetOneAsync(c => c.CategoriesId == id);

            if (category is not null)
            {
                _CategoriesRepository.Delete(category);
                await _CategoriesRepository.CommitAsync();

                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }
}
