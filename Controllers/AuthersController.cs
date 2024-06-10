using bookshop.Data;
using bookshop.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace bookshop.Controllers
{
	public class AuthersController : Controller
	{
		ApplicationDbContext Context;

		public AuthersController(ApplicationDbContext Context)
		{
			this.Context = Context;
		}
		public IActionResult Index()
		{
			var Authers = Context.Authers.ToList(); // من خلالها جبت الداتا من الداتا بيس على شكل ليست
			var AutherVM = new List<AutherVM>();
			foreach (var auther in Authers)
			{
				var autherVM = new AutherVM()
				{
					Id = auther.Id,
					AutherName = auther.AutherName,
					CreatedOn = DateTime.Now,
					UpdateOn = DateTime.Now,

				};
				AutherVM.Add(autherVM);


			}
			return View(AutherVM);

		}
		public IActionResult Create()
		{
			return View("Form");
		}
	}
}
