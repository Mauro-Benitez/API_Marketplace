using API_Marketplace.Domain.Entities;

namespace API_Marketplace.Infraestructure.Repository
{
    public interface IProdutoRepository
    {
        Produto InserirProduto(Produto produto);
        Produto AtualizarProduto(Produto produto);
        List<Produto> ListarProdutos();        
        Produto GetByIdProduto(Guid Id);
        void DeletarProduto (Guid Id);
    }
}
