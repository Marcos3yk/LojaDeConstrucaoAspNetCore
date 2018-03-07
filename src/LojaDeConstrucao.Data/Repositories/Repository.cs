using System.Collections.Generic;
using System.Linq;
using LojaDeConstrucao.Domain;

namespace LojaDeConstrucao.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual TEntity GetById(int id)
        {
            var query = _context.Set<TEntity>().Where(e => e.Id == id);
              
            if(query.Any()){
                return  query.First();
            }
            return null;            
        }

        public virtual IEnumerable<TEntity> All()
        {
            var query = _context.Set<TEntity>();

            if(query.Any())
                return query.ToList();

            return new List<TEntity>();
        }
         public virtual void Salvar(TEntity entity){
             _context.Set<TEntity>().Add(entity);
             _context.SaveChanges();             
         }
    }
}