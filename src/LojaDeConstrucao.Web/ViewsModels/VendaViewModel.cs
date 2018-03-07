using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaDeConstrucao.Web.ViewsModels
{
    public class VendaViewModel
    {
        [Required(ErrorMessage="Informe o nome do cliente")]
        public string NomeCliente {get; set;}
        [Required]
        public int IdProduto {get; set;}
        [Required]
        public int Quantidade {get; set;}
        public IEnumerable<ProdutoViewModel> Produtos { get; set; }
    }
}