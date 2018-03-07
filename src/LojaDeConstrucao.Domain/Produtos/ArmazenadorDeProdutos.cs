using LojaDeConstrucao.Domain.Dtos;

namespace LojaDeConstrucao.Domain.Produtos
{
    public class ArmazenadorDeProdutos
    {
        private readonly IRepository<Produto> _produtoRepository;
        private readonly IRepository<Categoria> _categoriaRepository;

        public ArmazenadorDeProdutos(IRepository<Produto> produtoRepository,
            IRepository<Categoria> categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }
        public void Armazenar(int id, string nome, int idCategoria, decimal preco, int qtdeEstoque)
        {
            var categoria = _categoriaRepository.GetById(idCategoria);
            DomainException.When(categoria == null, "Categoria Inválida");

            var produto = _produtoRepository.GetById(id);
            if(produto == null)
            {
                produto = new Produto(nome, categoria, preco, qtdeEstoque);
                _produtoRepository.Salvar(produto);
            }
            else
            {
                produto.Update(nome, categoria, preco, qtdeEstoque);
            }
        }
    }
}