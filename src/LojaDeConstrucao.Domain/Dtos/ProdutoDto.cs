namespace LojaDeConstrucao.Domain.Dtos
{
    public class ProdutoDto
    {
        public int Id{get; private set;}
        public string Nome{get; private set;}
        public int IdCategoria { get;private set; }
        public decimal Preco {get; private set;}
        public int QtdeEstoque {get; private set;}
    }
}