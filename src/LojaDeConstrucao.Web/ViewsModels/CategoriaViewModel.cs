using System.ComponentModel.DataAnnotations;

namespace LojaDeConstrucao.Web.ViewsModels
{
    public class CategoriaViewModel
    {
        public int Id{get;set;}
        [Required(ErrorMessage="Preencha o campo Nome")]
        public string Nome{get;set;}
    }
}