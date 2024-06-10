using bookshop.Data;
using bookshop.ViewModel;
using bookshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace bookshop.Controllers
{
    public class BookController : Controller
    {
        ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BookController(ApplicationDbContext Context ,IWebHostEnvironment webHostEnvironment)
        {
            this.context= Context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            var books = context.Books.Include(books => books.Auther)
                .Include(books => books.Category)
                .ThenInclude(books => books.Category).ToList();
            foreach (var item in books)
            {
                Console.WriteLine($"titel is {item.Titel} and Category is: {item.Category}");
                foreach (var item2 in item.Category)
                {
                    Console.WriteLine($"{item2.Category.Name}");
                }
            }
            var BookVM = new List<BookVM>();
            foreach (var book in books)
            {
                var bookVM = new BookVM()
                {
                    Id = book.Id,
                    Titel = book.Titel,
                    Auther = book.Auther.AutherName,
                    Publisher = book.Publisher,
                    PublishDate = book.PublishDate,
                    ImgURL = book.IMGurl,
                    Category = new List<string>(),
                };
                foreach(var c in book.Category)
                {
                    bookVM.Category.Add(c.Category.Name);
                }
                    BookVM.Add(bookVM);

            }
            return View();
        }
            [HttpGet] // to creare 
            public IActionResult Create()
            {
                var authers = context.Authers.OrderBy(e => e.AutherName).ToList();

                var ListAtuthar = new List<SelectListItem>();

                foreach (var auther in authers)
                {
                    ListAtuthar.Add(new SelectListItem
                    {
                        Value = auther.Id.ToString(),
                        Text = auther.AutherName,

                    });

                }
                var categories = context.Categories.OrderBy(e => e.Name).ToList();
                var ListCategory = new List<SelectListItem>();

                foreach (var category in categories)
                {
                    ListCategory.Add(new SelectListItem
                    {
                        Value = category.Id.ToString(),
                        Text = category.Name,
                    });

                }
                var VMAuther = new CreateBookVM
                {
                    Auther = ListAtuthar,
                    Category = ListCategory,
                };
                return View(VMAuther);
            }
            [HttpPost] // to save
            public IActionResult Create(CreateBookVM ViewModel)
            {
                String ImgName = null;
                if (ViewModel.ImgURL != null)
                {
                    ImgName = Path.GetFileName(ViewModel.ImgURL.FileName);

                    var path = Path.Combine($"{webHostEnvironment.WebRootPath}/Img/Books", ImgName);
                    var Stream = System.IO.File.Create(path);
                    ViewModel.ImgURL.CopyTo(Stream);


                }
                if (!ModelState.IsValid)
                {
                    return View("Create", ViewModel);
                }
                var book = new Book
                {
                    Titel = ViewModel.Titel,
                    AutherID = ViewModel.AutherID,
                    Publisher = ViewModel.Publisher,
                    PublishDate = ViewModel.PublishDate,
                    IMGurl = ImgName,
                    Description = ViewModel.Description,
                    Category = ViewModel.SelectedCategory.Select(Id => new BookCategory
                    {
                        CategoryId = Id,
                    }).ToList(),


                };
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("Index");



            }


       
        
    }
}
