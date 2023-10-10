﻿using MyFirstMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MyFirstMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
            
        }

        public DbSet<GamesModel> Games { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
