using LojaDeConstrucao.Domain.Dtos;

namespace LojaDeConstrucao.Domain.Produtos
{
    public class ArmazenadorDeCategoria
    {
        private readonly IRepository<Categoria> _categoriaRepository;
        public ArmazenadorDeCategoria(IRepository<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Armazenar(int id, string nome){
            var categoria = _categoriaRepository.GetById(id);
            if(categoria == null)
            {
                categoria = new Categoria(nome);
                _categoriaRepository.Salvar(categoria);
            }else
            {
                categoria.Update(nome);
            }
        }
    }
}