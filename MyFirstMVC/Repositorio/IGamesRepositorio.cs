using MyFirstMVC.Models;
using System.Collections.Generic;

namespace MyFirstMVC.Repositorio
{
    public interface IGamesRepositorio
    {
        GamesModel ListarPorId(int id);
        List<GamesModel> BuscarGames(int usuarioId);
        GamesModel Adicionar(GamesModel games);
        GamesModel Atualizar(GamesModel games);
        bool Apagar(int id);
    }
}
