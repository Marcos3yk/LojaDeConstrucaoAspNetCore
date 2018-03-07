using System.ComponentModel.DataAnnotations;

namespace LojaDeConstrucao.Web.ViewsModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email {get; set;}
        [Required]
        public string Senha {get; set;}
    }
}