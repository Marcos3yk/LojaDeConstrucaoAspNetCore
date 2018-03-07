using System.Threading.Tasks;
using LojaDeConstrucao.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace LojaDeConstrucao.Data.Identity
{
    
    public class Authentication : IAuthentication
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Authentication(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Authenticate(string email, string senha)
        {
            var result = await _signInManager.PasswordSignInAsync(email, senha, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}