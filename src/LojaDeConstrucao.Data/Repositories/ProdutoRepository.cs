using System.Collections.Generic;
using System.Linq;
using LojaDeConstrucao.Domain.Produtos;
using Microsoft.EntityFrameworkCore;

namespace LojaDeConstrucao.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>
    {
        public ProdutoRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        public override Produto GetById(int id)
        {
            var query = _context.Set<Produto>().Include(p => p.Categoria).Where(e => e.Id == id);
            if(query.Any())
                return query.First();
            return null;
        }

        public override IEnumerable<Produto> All()
        {
            var query = _context.Set<Produto>().Include(p => p.Categoria);

            return query.Any() ? query.ToList() : new List<Produto>();
        }
    }
}