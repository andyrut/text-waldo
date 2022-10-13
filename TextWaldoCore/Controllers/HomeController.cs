using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TextWaldoCore.HelperClasses;
using TextWaldoCore.Models;
using TextWaldoCore.Models.Home;

namespace TextWaldoCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // dependency injection for 
        // reading the path to the root dir 
        readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            var model = new IndexModel
            {
                Items = System.IO.File.ReadAllText(Path.Combine(_env.ContentRootPath, "Data", "Items.txt")).Split('\n').ToList()
            };
            model.Items = model.Items.Select(item => item.Trim()).ToList();
            model.Items.Shuffle();
            return View(model);
        }

        public IActionResult Yes()
        {
            return View();
        }

        public IActionResult No()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}