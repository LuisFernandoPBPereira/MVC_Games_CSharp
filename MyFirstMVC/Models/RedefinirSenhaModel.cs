using System.ComponentModel.DataAnnotations;

namespace MyFirstMVC.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o email")]
        [EmailAddress(ErrorMessage = "Digite o email corretamente")]
        public string Email { get; set; }
    }
}
