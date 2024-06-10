using bookshop.Data;
using Microsoft.AspNetCore.Mvc;
using bookshop.Models;
using bookshop.ViewModel;
using System.Linq;

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
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Create(CategoryViewModel categorieVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", categorieVM);
            }
            var zozo = new Category
            {
                Name = categorieVM.Name
            };
            try
            {
				soso.Categories.Add(zozo);

				soso.SaveChanges();
				return RedirectToAction("Index");
			}
            catch
            {
                
				return View("Create", categorieVM);
			}

			
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var CategoryInDB = soso.Categories.Find(id);
           
            if( CategoryInDB == null){
                return NotFound();
            }
            var ViewModel = new CategoryViewModel
            {
                Id = id,
                Name = CategoryInDB.Name
            };
            return View("Create", ViewModel);
            
        }
        [HttpPost]
        public IActionResult Edit(CategoryViewModel newvalue)  
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newvalue);
            }
            var zozo = soso.Categories.Find(newvalue.Id);
           
            if (zozo == null)
            {
                return NotFound();
            }
            zozo.Name = newvalue.Name;
            zozo.UpdateOn= DateTime.Now;
			soso.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Details(int Id)
        {
            var category = soso.Categories.Find(Id);
            if (category == null)
            {
                return NotFound();
            }
            var ViewModel = new CategoryViewModel
            {
                Id = Id,
                Name = category.Name,
                CreatedOn = category.CreatedOn,
                UpdateOn = category.UpdateOn
			};

			return View("Details", ViewModel);

        }
         public IActionResult Delete(int Id)
        {
            var category = soso.Categories.Find(Id);
            if (category == null)
            {
                return NotFound();
            }
            soso.Remove(category);
            soso.SaveChanges();
            return Ok();

        }

        public IActionResult CheckName(CategoryViewModel newvalue)
        {
            var IsExsist = soso.Categories.Any(CategoryModel => CategoryModel.Name == newvalue.Name);
            return Json("IsExsist");
        }
   
    }
}

