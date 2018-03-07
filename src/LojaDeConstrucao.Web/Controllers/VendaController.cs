using System.Linq;
using LojaDeConstrucao.Domain;
using LojaDeConstrucao.Domain.Produtos;
using LojaDeConstrucao.Domain.Vendas;
using LojaDeConstrucao.Web.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeConstrucao.Web.Controllers
{
    [Authorize]
    public class VendaController : Controller
    {
        private readonly VendaFactory _saleFactory;
        private readonly IRepository<Produto> _produtoRepository;
    

        public VendaController(VendaFactory saleFactory, IRepository<Produto> produtoRepository)
        {
            _saleFactory = saleFactory;
            _produtoRepository = produtoRepository;
        }
        
        public IActionResult Create()
        {
            var products = _produtoRepository.All();
            
            var productsViewModel = products.Select(c => new ProdutoViewModel{ Id = c.Id, Nome = c.Nome });
            return View(new VendaViewModel{Produtos = productsViewModel});
        }

        [HttpPost]
        public IActionResult Create(VendaViewModel viewModel)
        {
            _saleFactory.Create(viewModel.NomeCliente, viewModel.IdProduto, viewModel.Quantidade);
            return Ok();
        }   
    }
}