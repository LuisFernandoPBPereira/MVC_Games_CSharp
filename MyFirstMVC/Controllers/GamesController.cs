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
        public IActionResult Editar(int id)
        {
            GamesModel games = _gamesRepositorio.ListarPorId(id);
            return View(games);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            GamesModel games = _gamesRepositorio.ListarPorId(id);
            return View(games);
        }

        public IActionResult Apagar(int id)
        {
            _gamesRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(GamesModel game)
        {
            _gamesRepositorio.Adicionar(game);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(GamesModel game)
        {
            _gamesRepositorio.Atualizar(game);
            return RedirectToAction("Index");
        }
    }
}
