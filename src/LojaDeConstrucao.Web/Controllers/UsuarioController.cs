using System.Linq;
using System.Threading.Tasks;
using LojaDeConstrucao.Domain.Account;
using LojaDeConstrucao.Web.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeConstrucao.Web.Controllers
{
    [Authorize(Roles = "Admin, Manager")]
    public class UsuarioController : Controller
    {
        private readonly IManager _manager;

        public UsuarioController(IManager manager)
        {
            _manager = manager;
        }

         public IActionResult Index()
        {
            var usuarios = _manager.ListAll();
            var usuariosViewModel = usuarios.Select(u => new UsuarioViewModel{Id = u.Id, Email = u.Email});
            return View(usuariosViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioViewModel viewModel)
        {
            await _manager.CreateAsync(viewModel.Email, viewModel.Senha, viewModel.Role);
            return Ok();
        }

    }
}