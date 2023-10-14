using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.Filters;
using MyFirstMVC.Models;
using MyFirstMVC.Repositorio;
using System.Collections.Generic;

namespace MyFirstMVC.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IGamesRepositorio _gamesRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio,
                                 IGamesRepositorio gamesRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _gamesRepositorio= gamesRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarUsuarios();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id); 
            return View(usuario);
        }

        public IActionResult ListarGamesPorUsuarioId(int id)
        {
            List<GamesModel> games = _gamesRepositorio.BuscarGames(id);
            return PartialView("_GamesUsuario", games);
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar o usuário, tente novamente! Detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não foi possível apagar o usuário, tente novamente!";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível apagar o usuário, tente novamente! Detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;
                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil
                    };
                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemSucesso"] = $"Ops, não foi possível alterar o jogo, tente novamente! Detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
