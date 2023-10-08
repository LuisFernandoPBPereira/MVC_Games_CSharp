using MeuPrimeiroMVC.Data;
using MeuPrimeiroMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstMVC.Repositorio
{
    public class GamesRepositorio : IGamesRepositorio
    {
        private readonly BancoContext _bancoContext;
        public GamesRepositorio(BancoContext bancoContext) 
        {
            _bancoContext= bancoContext;
        }
        public List<GamesModel> BuscarGames()
        {
            return _bancoContext.Games.ToList();
        }
        public GamesModel Adicionar(GamesModel games)
        {
            //gravar no banco de dados
            _bancoContext.Games.Add(games);
            _bancoContext.SaveChanges();
            return games;
        }
    }
}
