using MyFirstMVC.Models;
using Microsoft.EntityFrameworkCore;
using MyFirstMVC.Data.Map;

namespace MyFirstMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
            
        }

        public DbSet<GamesModel> Games { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
