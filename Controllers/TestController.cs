using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using tuwiq.Models;

namespace tuwiq.Controllers
{

    public class TestController : Controller
    {
        List<string> kitten;
        List<Cats> cats;
        Dictionary<int, string> DicKitty;
        private readonly ILogger<TestController> _logger;


        public TestController(ILogger<TestController> logger)
        {
            kitten = new List<string>();
            kitten.Add("lolo");
            kitten.Add("meme");
            kitten.Add("coco");
            kitten.Add("nana");


            DicKitty = new Dictionary<int, string>();
            DicKitty.Add(1, "lele");
            DicKitty.Add(2, "kaka");
            DicKitty.Add(3, "fafa");
            DicKitty.Add(4, "bobo");


            cats = new List<Cats>()
            {
                new Cats{Id=1, Name="nana"},
                new Cats{Id=2, Name="keke"},
                new Cats{Id=3, Name="momo"},
                new Cats{Id=4, Name="fafo"},
                new Cats{Id=5, Name="lesa"}
            };

            _logger = logger;
        }
        public IActionResult Index()
        {

            ViewData["kitten"] = kitten;
            ViewBag.DicKitty = cats;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string s)
        {
            var result = cats.Where(cat => cat.Name.ToLower().Contains(s.ToLower()));
            if (result != null)
            {
                ViewBag.result=result;
            }
            return View();
        }



    }
}
