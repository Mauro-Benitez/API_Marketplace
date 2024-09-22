using API_Marketplace.Domain.Entities;
using API_Marketplace.Infraestructure.DataBase;

namespace API_Marketplace.Infraestructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly SQLContext _sqlContext;

        public ProdutoRepository(SQLContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public Produto AtualizarProduto(Produto produto)
        {
             var prodDB = GetByIdProduto(produto.Id);

            if (prodDB is null) throw new ArgumentException("Produto não encontrado.");

            _sqlContext.Produtos.Entry(prodDB).CurrentValues.SetValues(produto);
            _sqlContext.SaveChanges();
            return prodDB;
        }

        public void DeletarProduto(Guid Id)
        {
            var result = _sqlContext.Produtos.FirstOrDefault(p => p.Id.Equals(Id));

            if(result == null)
            {
                throw new ArgumentException("Produto não encontrado.");
            }

            _sqlContext.Produtos.Remove(result);
            _sqlContext.SaveChanges();
        }

        public Produto GetByIdProduto(Guid id)
        {
            var result = _sqlContext.Produtos.FirstOrDefault(p => p.Id == id);

            if(result == null)
            {
                throw new ArgumentException("Produto não encontrado.");
            }

            return result;
        }

        public Produto InserirProduto(Produto produto)
        {
            _sqlContext.Produtos.Add(produto);
            _sqlContext.SaveChanges();
            return produto;
        
        }

        public List<Produto> ListarProdutos()
        {
            return _sqlContext.Produtos.ToList();           
        }
    }
}
