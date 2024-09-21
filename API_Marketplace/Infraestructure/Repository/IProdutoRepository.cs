using API_Marketplace.Domain.Entities;

namespace API_Marketplace.Infraestructure.Repository
{
    public interface IProdutoRepository
    {
        Produto Inserir(Produto produto);

        List<Produto> Listar();
        
        Produto GetById(int id);

        void Deletar (Produto produto);
    }
}
