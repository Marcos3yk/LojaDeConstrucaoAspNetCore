using LojaDeConstrucao.Domain.Produtos;

namespace LojaDeConstrucao.Domain.Vendas
{
    public class ItemVenda : Entity
    {
        public Produto Produto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }

        public ItemVenda(Produto produto, int quantidade)
        {
            DomainException.When(produto == null, "Produto é obrigatorio");
            DomainException.When(quantidade < 1, "Quantidade incorreta");
                        
            Produto = produto;
            Preco = Produto.Preco;
            Quantidade = quantidade;
            Total = Preco * Quantidade;
        }
    }
}