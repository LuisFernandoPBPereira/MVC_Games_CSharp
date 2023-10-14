using MyFirstMVC.Models;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.Repositorio;
using System.Collections.Generic;
using MyFirstMVC.Filters;
using MyFirstMVC.Helper;

namespace MyFirstMVC.Controllers
{
    [PaginaParaUsuarioLogado]
    public class GamesController : Controller
    {
        private readonly IGamesRepositorio _gamesRepositorio;
        private readonly ISessao _sessao;
        public GamesController(IGamesRepositorio gamesRepositorio,
                               ISessao sessao)
        {
            _gamesRepositorio= gamesRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            List<GamesModel> games = _gamesRepositorio.BuscarGames(usuarioLogado.Id);
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
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    game.UsuarioId = usuarioLogado.Id;
                    game = _gamesRepositorio.Adicionar(game);
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
                    UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                    game.UsuarioId = usuarioLogado.Id;
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
