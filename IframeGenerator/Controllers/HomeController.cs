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
            // Adres bilgisini model olarak geçiyoruz
            var model = new ContactViewModel
            {
                Address = "" // Baþlangýçta boþ, form gönderildikten sonra güncellenecek
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model); // Formdan gelen adres ile view'ý döndür
            }
            return View(new ContactViewModel()); // Model geçerli deðilse, boþ modelle döndür
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
