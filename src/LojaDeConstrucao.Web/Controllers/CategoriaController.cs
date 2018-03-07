
using System.Linq;
using LojaDeConstrucao.Domain;
using LojaDeConstrucao.Domain.Produtos;
using LojaDeConstrucao.Web.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeConstrucao.Web.Controllers
{

     [Authorize(Roles = "Admin, Manager")]
    public class CategoriaController : Controller
    {
        private readonly ArmazenadorDeCategoria _armazenadorDeCategoria;

        private readonly IRepository<Categoria> _categoriaRepository;

        public CategoriaController(ArmazenadorDeCategoria armazenadorDeCategoria, 
        IRepository<Categoria> categoriaRepository)
        {
            _armazenadorDeCategoria = armazenadorDeCategoria;
            _categoriaRepository = categoriaRepository;
        }
        public IActionResult Index()
        {
            var categorias = _categoriaRepository.All();
            var viewModels = categorias.Select(c => new CategoriaViewModel{ Id = c.Id, Nome = c.Nome });

            return View(viewModels);
        }        
        
        public IActionResult CreateOrEdit(int id)
        {
            if(id > 0)
            {
                var categoria = _categoriaRepository.GetById(id);            
                var categoriaViewModel = new CategoriaViewModel { Id = categoria.Id, Nome = categoria.Nome };
                return View(categoriaViewModel);
            }else
            {
                return View();
            }
            
        }
        [HttpPost]

        public IActionResult CreateOrEdit(CategoriaViewModel viewModel)
        {
            _armazenadorDeCategoria.Armazenar(viewModel.Id, viewModel.Nome);
            //return View();
            return RedirectToAction("Index");
        }
    }
}