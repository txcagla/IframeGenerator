using IframeGenerator.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IframeGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            // Adres bilgisini model olarak ge�iyoruz
            var model = new ContactViewModel
            {
                Address = "" // Ba�lang��ta bo�, form g�nderildikten sonra g�ncellenecek
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model); // Formdan gelen adres ile view'� d�nd�r
            }
            return View(new ContactViewModel()); // Model ge�erli de�ilse, bo� modelle d�nd�r
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
