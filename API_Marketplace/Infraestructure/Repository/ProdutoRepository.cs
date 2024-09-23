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


        /// <summary>
        /// Método responsável por atualziar um produto no banco de dados
        /// </summary>
        /// <param name="produto">Produto a ser cadastrado</param>
        /// <returns>Retorna o produto com as informações atualizadas</returns>
        /// <exception cref="ArgumentException"></exception>
        public Produto AtualizarProduto(Produto produto)
        {
             var prodDB = GetByIdProduto(produto.Id);

            if (prodDB is null) throw new ArgumentException("Produto não encontrado.");

            _sqlContext.Produtos.Entry(prodDB).CurrentValues.SetValues(produto);
            _sqlContext.SaveChanges();
            return prodDB;
        }


        /// <summary>
        /// Método responsável por deletar um produto no banco de dados
        /// </summary>
        /// <param name="Id">Id do usuário a ser deletado</param>
        /// <exception cref="ArgumentException"></exception>
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


        /// <summary>
        /// Método responsável por buscar um produto no banco de dados pelo Id cadastrado
        /// </summary>
        /// <param name="id">Id do usuário a ser buscado</param>
        /// <returns>Retorna um produto</returns>
        /// <exception cref="ArgumentException"></exception>
        public Produto GetByIdProduto(Guid id)
        {
            var result = _sqlContext.Produtos.FirstOrDefault(p => p.Id == id);

            if(result == null)
            {
                throw new ArgumentException("Produto não encontrado.");
            }

            return result;
        }


        /// <summary>
        /// Método responsável por inserir um produto no banco de dados
        /// </summary>
        /// <param name="produto">Novo objeto do tipo Produto</param>
        /// <returns>Retorna o Produto cadastrado</returns>
        public Produto InserirProduto(Produto produto)
        {
            _sqlContext.Produtos.Add(produto);
            _sqlContext.SaveChanges();
            return produto;
        
        }


        /// <summary>
        /// Método responsável por retornar todos os produtos cadastrados no banco de dados
        /// </summary>
        /// <returns></returns>
        public List<Produto> ListarProdutos()
        {
            
            return _sqlContext.Produtos.ToList();           
        }
    }
}
