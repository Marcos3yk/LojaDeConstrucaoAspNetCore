using System.Linq;
using LojaDeConstrucao.Domain;
using LojaDeConstrucao.Domain.Produtos;
using LojaDeConstrucao.Web.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeConstrucao.Web.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class ProdutoController : Controller
    {
        private readonly ArmazenadorDeProdutos _armazenadorDeProdutos;
        private readonly IRepository<Produto> _produtoRepository;
        private readonly IRepository<Categoria> _categoriaRepository;

        public ProdutoController(ArmazenadorDeProdutos armazenadorDeProdutos,
            IRepository<Categoria> categoriaRepository,
            IRepository<Produto> produtoRepository)
        {
            _armazenadorDeProdutos = armazenadorDeProdutos;
            _categoriaRepository = categoriaRepository;
            _produtoRepository = produtoRepository;
        }
        
        public IActionResult Index()
        {
            var produtos = _produtoRepository.All();
            if(produtos.Any())
            {
                var viewsModels = produtos.Select(p => new ProdutoViewModel { Id = p.Id, Nome = p.Nome, NomeCategoria = p.Categoria.Nome});
                return View(viewsModels);
            }
            return View();
        }

        public IActionResult CreateOrEdit(int id)
        {
            var viewModel = new ProdutoViewModel();
            var categorias = _categoriaRepository.All();
            if(categorias.Any())
                viewModel.Categorias = categorias.Select(c => new CategoriaViewModel{ Id = c.Id, Nome = c.Nome });
            
            if(id > 0)
            {
                var produto = _produtoRepository.GetById(id);
                viewModel.Id = produto.Id;
                viewModel.Nome = produto.Nome;
                viewModel.IdCategoria = produto.Categoria.Id;
                viewModel.Preco = produto.Preco;
                viewModel.QtdeEstoque = produto.QtdeEstoque;
                return View(viewModel);
            }
            return View(viewModel);
            
        }

        [HttpPost]
        public IActionResult CreateOrEdit(ProdutoViewModel viewModel)
        {
            _armazenadorDeProdutos.Armazenar(viewModel.Id, viewModel.Nome, viewModel.IdCategoria, viewModel.Preco, viewModel.QtdeEstoque);
            return RedirectToAction("Index");
        }   
    }
}