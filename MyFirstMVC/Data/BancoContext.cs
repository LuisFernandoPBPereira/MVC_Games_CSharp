using MeuPrimeiroMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuPrimeiroMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
            
        }

        public DbSet<GamesModel> Games { get; set; }
    }
}
