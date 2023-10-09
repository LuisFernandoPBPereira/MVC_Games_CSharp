using System.ComponentModel.DataAnnotations;

namespace MeuPrimeiroMVC.Models
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
    }
}
