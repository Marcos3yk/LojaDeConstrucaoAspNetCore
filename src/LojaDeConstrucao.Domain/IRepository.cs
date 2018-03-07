

using System.Collections.Generic;

namespace LojaDeConstrucao.Domain
{
    public interface IRepository<TEntity>
    {
         TEntity GetById(int id);
         void Salvar(TEntity entity);         
         IEnumerable<TEntity>All();
    }
}