using MyFirstMVC.Data;
using MyFirstMVC.Models;
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
        public GamesModel ListarPorId(int id)
        {
            return _bancoContext.Games.FirstOrDefault(x => x.Id == id);
        }
        public List<GamesModel> BuscarGames(int usuarioId)
        {
            return _bancoContext.Games.Where(x => x.UsuarioId == usuarioId).ToList();
        }
        public GamesModel Adicionar(GamesModel games)
        {
            //gravar no banco de dados
            _bancoContext.Games.Add(games);
            _bancoContext.SaveChanges();
            return games;
        }

        public GamesModel Atualizar(GamesModel games)
        {
            GamesModel gamesDB = ListarPorId(games.Id);

            if (gamesDB == null) throw new System.Exception("Houve um erro na atualização do Game");

            gamesDB.NomeJogo = games.NomeJogo;
            gamesDB.Estudio = games.Estudio;
            gamesDB.Plataforma = games.Plataforma;

            _bancoContext.Games.Update(gamesDB);
            _bancoContext.SaveChanges();

            return gamesDB;
        }

        public bool Apagar(int id)
        {
            GamesModel gamesDB = ListarPorId(id);

            if (gamesDB == null) throw new System.Exception("Houve um erro ao apagar o Game");
            _bancoContext.Games.Remove(gamesDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
