﻿using System.ComponentModel.DataAnnotations;

namespace MyFirstMVC.Models
{
    public class GamesModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do jogo")]
        public string NomeJogo { get; set; }
        [Required(ErrorMessage = "Digite o nome do estúdio")]
        public string Estudio { get; set; }
        [Required(ErrorMessage = "Digite o nome da plataforma")]
        public string Plataforma { get; set; }

        public int? UsuarioId { get; set; }

        public UsuarioModel Usuario { get; set; }
    }
}
