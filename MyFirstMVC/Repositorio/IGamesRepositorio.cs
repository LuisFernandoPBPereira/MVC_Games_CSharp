using MeuPrimeiroMVC.Models;
using System.Collections.Generic;

namespace MyFirstMVC.Repositorio
{
    public interface IGamesRepositorio
    {
        List<GamesModel> BuscarGames();
        GamesModel Adicionar(GamesModel games);
    }
}
