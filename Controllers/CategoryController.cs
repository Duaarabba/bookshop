using bookshop.Data;
using Microsoft.AspNetCore.Mvc;

namespace bookshop.Controllers
{
    public class CategoryController : Controller
    {
         ApplicationDbContext soso;

        public CategoryController(ApplicationDbContext Context)
        {
            this.soso = Context;
        }

        public IActionResult Index()
        {
         
            var categories = soso.Categories.ToList();
            return View(categories);
        }
    }
}
