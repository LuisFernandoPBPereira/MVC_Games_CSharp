using MyFirstMVC.Models;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.Repositorio;
using System.Collections.Generic;

namespace MyFirstMVC.Controllers
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
            try
            {
                bool apagado = _gamesRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Jogo apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não foi possível apagar o jogo, tente novamente!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível apagar o jogo, tente novamente! Detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(GamesModel game)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _gamesRepositorio.Adicionar(game);
                    TempData["MensagemSucesso"] = "Jogo cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(game);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar o jogo, tente novamente! Detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Alterar(GamesModel game)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _gamesRepositorio.Atualizar(game);
                    TempData["MensagemSucesso"] = "Jogo alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", game);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemSucesso"] = $"Ops, não foi possível alterar o jogo, tente novamente! Detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
