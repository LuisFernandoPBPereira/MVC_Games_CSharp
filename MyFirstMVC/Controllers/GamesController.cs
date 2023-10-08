using MeuPrimeiroMVC.Models;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.Repositorio;
using System.Collections.Generic;

namespace MeuPrimeiroMVC.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesRepositorio _gamesRepositorio;
        public GamesController(IGamesRepositorio gamesRepositorio)
        {
            _gamesRepositorio= gamesRepositorio;
        }
        public IActionResult Index()
        {
            List<GamesModel> games = _gamesRepositorio.BuscarGames();
            return View(games);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar()
        {
            return View();
        }
        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(GamesModel game)
        {
            _gamesRepositorio.Adicionar(game);
            return RedirectToAction("Index");
        }
    }
}
