using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaDeConstrucao.Domain.Account
{
    public interface IManager
    {
        Task<bool> CreateAsync(string email, string senha, string role /*papel do usuario*/);
        List<IUser> ListAll();
    }

}