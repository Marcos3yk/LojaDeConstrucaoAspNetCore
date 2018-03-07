using System;
using LojaDeConstrucao.Domain.Produtos;

namespace LojaDeConstrucao.Domain.Vendas
{
    public class Venda : Entity
    {
       public string NomeCliente { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public decimal Total { get; private set; }
        public ItemVenda Item { get; private set; }

        public Venda(string nomeCliente, Produto produto, int quantidade)
        {
            DomainException.When(string.IsNullOrEmpty(nomeCliente), "O Nome do cliente é obrigatorio");
            Item = new ItemVenda(produto, quantidade);
            CriadoEm = DateTime.Now;
            NomeCliente = nomeCliente;
            Total = produto.Preco * quantidade;
        } 
    }
}