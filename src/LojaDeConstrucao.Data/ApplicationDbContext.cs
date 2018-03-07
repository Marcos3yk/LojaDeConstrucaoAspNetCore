using LojaDeConstrucao.Data.Identity;
using LojaDeConstrucao.Domain.Produtos;
using LojaDeConstrucao.Domain.Vendas;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LojaDeConstrucao.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>  {
        
        
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
    }
}