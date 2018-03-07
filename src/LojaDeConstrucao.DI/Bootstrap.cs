using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LojaDeConstrucao.Data;
using LojaDeConstrucao.Domain;
using LojaDeConstrucao.Domain.Produtos;
using LojaDeConstrucao.Data.Repositories;
using LojaDeConstrucao.Domain.Vendas;
using LojaDeConstrucao.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using LojaDeConstrucao.Domain.Account;

namespace LojaDeConstrucao.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(conection));
            services.AddIdentity<ApplicationUser, IdentityRole>(config => {

                    config.Password.RequireDigit = false;
                    config.Password.RequiredLength = 3;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireUppercase = false;
                    
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders(); 
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");

            services.AddSingleton(typeof(IRepository<Produto>), typeof(ProdutoRepository));    
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton(typeof(IAuthentication), typeof(Authentication));
            services.AddSingleton(typeof(IManager), typeof(Manager));
            services.AddSingleton(typeof(ArmazenadorDeCategoria));
            services.AddSingleton(typeof(ArmazenadorDeProdutos));
            services.AddSingleton(typeof(VendaFactory));
            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
