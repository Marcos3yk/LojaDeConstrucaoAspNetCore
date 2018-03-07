using System.ComponentModel.DataAnnotations;

namespace LojaDeConstrucao.Web.ViewsModels
{
    public class UsuarioViewModel
    {
        public string Id {get;set;}
        [Required]
        public string Email {get; set;}
        [Required]
        public string Senha{get;set;}
        [Required]
        public string Role{get;set;}

    }
}