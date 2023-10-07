using Microsoft.AspNetCore.Mvc;

namespace MeuPrimeiroMVC.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
