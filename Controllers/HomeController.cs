using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tuwiq.Data;
using tuwiq.Models;

namespace tuwiq.Controllers
{
    public class HomeController : Controller
    {
        //List<string> kitten;
        //Dictionary<int, string> DicKitty;
        //private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        public IActionResult Index()
        {
            var cats=_context.Cats.ToList();
            return View(cats);
        }
        [HttpPost]
        public IActionResult Index(string search)
        {
            var cats = _context.Cats.ToList().Where(cat => cat.Name.ToLower().Contains(search.ToLower()));
            return View(cats);
        }

        public IActionResult Delete(int id)// delete a record
        {
            var killCat=_context.Cats.SingleOrDefault(x=>x.Id== id);
            _context.Cats.Remove(killCat);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)//go to edit view
        {
            var EditCat = _context.Cats.SingleOrDefault(x => x.Id == id);
            return View(EditCat);
        }
        public IActionResult Update(Cats cat)// apply the changes to the record
        {
            _context.Cats.Update(cat);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult CreateCat( Cats cats)// create a new record
        {
            _context.Cats.Add(cats);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string Welcome(int id)
        {
            return "Welcome Stranger "+ id+1;
        }


        /*public int GetCount()
        {
            //return kitten.Count;
            //return DicKitty.Count;
        }

        /*public string Search(string name)
        {
            /*foreach(var cat in kitten)
            {
                if(cat.Contains(name)) return "Founded";
            }
            var x = kitten.Find(cat => cat.Contains(name));
            if (x != null) return "Founded";
            return "Not Founded";*/
            //var x = kitten.Find(cat => cat.ToLower().Contains(name.ToLower()));
            //var x = DicKitty.FirstOrDefault(cat => cat.Value.ToLower().Contains(name.ToLower()));
            //return x.Value != null ? "Found" : "Not Found";

        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}