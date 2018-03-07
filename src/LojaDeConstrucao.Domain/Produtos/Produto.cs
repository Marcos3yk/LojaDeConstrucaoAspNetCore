using System;

namespace LojaDeConstrucao.Domain.Produtos
{
    public class Produto : Entity
    {
        
        public string Nome{get; private set;}
        public virtual Categoria Categoria { get;private set; }
        public decimal Preco {get; private set;}
        public int QtdeEstoque {get; private set;}

        private Produto(){}

        public Produto(string nome, Categoria categoria, decimal preco, int qtdeEstoque)
        {
            Validacao(nome, categoria, preco, qtdeEstoque);
            SetValores(nome, categoria, preco, qtdeEstoque);
        }

        public void Update(string nome, Categoria categoria, decimal preco, int qtdeEstoque){
            Validacao(nome, categoria, preco, qtdeEstoque);
            SetValores(nome, categoria, preco, qtdeEstoque);
        }

        private void SetValores(string nome, Categoria categoria, decimal preco, int qtdeEstoque)
        {
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
            QtdeEstoque = qtdeEstoque;
        }

        private static void Validacao(string nome, Categoria categoria, decimal preco, int qtdeEstoque)
        {
            DomainException.When(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            DomainException.When(categoria == null, "A categoria é obrigatória");
            DomainException.When(preco < 0, "O preço é obrigatório");
            DomainException.When(qtdeEstoque < 0, "A quantidade do estoque é obrigatória");
        }

        public void RemoverDoEstoque(int quantidade)
        {
            DomainException.When((QtdeEstoque - quantidade) < 0, "Quantidade invalida do produto no estoque");
            QtdeEstoque -= quantidade;
        }

    }
}