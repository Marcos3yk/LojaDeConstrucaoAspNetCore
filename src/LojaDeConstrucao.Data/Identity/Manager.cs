using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaDeConstrucao.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace LojaDeConstrucao.Data.Identity
{
    public class Manager : IManager 
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public Manager(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext dbContext)            
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public async Task<bool> CreateAsync(string email, string senha, string role /*papel do usuario*/)
        {
            var user = new ApplicationUser { UserName = email, Email = email};
            var result = await _userManager.CreateAsync(user, senha);

            if(result.Succeeded)
            {    
                await _userManager.AddToRoleAsync(user, role);
                return true;
            }

            return false;
        }

        public List<IUser> ListAll(){

            var users = _dbContext.Users;

            return users.Any() ? users.Select(u => (IUser)u).ToList() : new List<IUser>();
        }
    }
}