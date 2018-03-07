namespace LojaDeConstrucao.Domain.Produtos
{
    public class Categoria : Entity
    {        
        public Categoria(){}            
        public string Nome{get;private set;}

        public Categoria(string nome)
        {
            ValidateNomeAndSetNome(nome);
        }

        public void Update(string nome){
            ValidateNomeAndSetNome(nome);
            
        }

        private void ValidateNomeAndSetNome(string nome)
        {
            DomainException.When(string.IsNullOrEmpty(nome), "Nome é um campo obrigatório");
            Nome = nome;
        }

        

    }

    
}