using System.Threading.Tasks;

namespace LojaDeConstrucao.Domain.Account
{
    public interface IAuthentication
    {
        Task<bool> Authenticate(string email, string senha);
        Task Logout();
    }
}