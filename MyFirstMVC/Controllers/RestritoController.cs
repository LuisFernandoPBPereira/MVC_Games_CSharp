using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.Filters;

namespace MyFirstMVC.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
