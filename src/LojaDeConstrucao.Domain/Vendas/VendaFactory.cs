using LojaDeConstrucao.Domain.Produtos;

namespace LojaDeConstrucao.Domain.Vendas
{
    public class VendaFactory
    {
        private readonly IRepository<Venda> _vendaRepository;
        private readonly IRepository<Produto> _productRepository;

        public VendaFactory(IRepository<Venda> vendaRepository, IRepository<Produto> productRepository)
        {
            _vendaRepository = vendaRepository;
            _productRepository = productRepository;
        }

        public void Create(string nomeCliente, int IdProduto, int quantidade)
        {
            var produto = _productRepository.GetById(IdProduto);
            produto.RemoverDoEstoque(quantidade);

            var venda = new Venda(nomeCliente, produto, quantidade);
            _vendaRepository.Salvar(venda);
        }
    }
}