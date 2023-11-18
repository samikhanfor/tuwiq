using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tuwiq.Data;
using tuwiq.Models;

namespace tuwiq.Controllers
{
	public class DashboardController : Controller
	{
		private readonly ApplicationDbContext _context;

		public DashboardController(ApplicationDbContext context)
		{
			_context = context;
		}
		[Authorize]
		public IActionResult Index()
		{
			var cats = _context.Cats.ToList();
			return View(cats);
		}

		[HttpPost]
		public IActionResult Index(string search)
		{
			var cats = _context.Cats.ToList().Where(cat => cat.Name.ToLower().Contains(search.ToLower()));
			TempData["search"] = search;
			return View(cats);
		}

		public IActionResult CreateCat(Cats cats)// create a new record
		{
			_context.Cats.Add(cats);
			_context.SaveChanges();
			return RedirectToAction("index");
		}

		public IActionResult Delete(int id)// delete a record
		{
			var killCat = _context.Cats.SingleOrDefault(x => x.Id == id);
			if (killCat != null)
			{
				_context.Cats.Remove(killCat);
				_context.SaveChanges();
				TempData["delete"]= "done";
			}
			return RedirectToAction("index");
		}
	}
}
