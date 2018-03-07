using System.Threading.Tasks;

namespace LojaDeConstrucao.Domain
{
    public interface IUnitOfWork
    {
         Task Commit();
    }
}