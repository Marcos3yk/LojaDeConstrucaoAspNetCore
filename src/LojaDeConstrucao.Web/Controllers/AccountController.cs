using System.Threading.Tasks;
using LojaDeConstrucao.Domain.Account;
using LojaDeConstrucao.Web.ViewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LojaDeConstrucao.Web.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly IAuthentication _authentication;

        public AccountController(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authentication.Authenticate(model.Email, model.Senha);

            if(result){
                return Redirect("/");
            }else{
                ModelState.AddModelError(string.Empty,"Login Inválido");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _authentication.Logout();
            return Redirect("/Account/Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        
    }
}