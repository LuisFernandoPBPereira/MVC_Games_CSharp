using Microsoft.AspNetCore.Mvc;

namespace MyFirstMVC.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
