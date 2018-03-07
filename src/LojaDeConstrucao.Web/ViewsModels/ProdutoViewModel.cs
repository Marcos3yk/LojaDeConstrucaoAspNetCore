using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaDeConstrucao.Web.ViewsModels
{
    public class ProdutoViewModel
    {
        public int Id {get; set;}
        [Required]
        public string Nome {get; set;}
        [Required]
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Quantidade de estoque inválida")]
        public int QtdeEstoque {get;  set;}
        public IEnumerable<CategoriaViewModel> Categorias { get; set; }
    }
}