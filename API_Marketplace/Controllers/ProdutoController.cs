using API_Marketplace.Domain.Entities;
using API_Marketplace.Infraestructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Marketplace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoRepository _productRepository;

        public ProdutoController(IProdutoRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Retorna todos os produtos cadastrados.
        /// Necessário se autenticar.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(List<Produto>))]
        public IActionResult GetAll()
        {
            var result = _productRepository.ListarProdutos();
            return Ok(result);
        }


        /// <summary>
        /// Retorna um produto por ID.
        ///  Necessário se autenticar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Produto))]
        public IActionResult GetById(Guid id)
        {
            var result = _productRepository.GetByIdProduto(id);

            if (result == null) return NotFound();

            return Ok(result);
        }



        /// <summary>
        ///Cadastrar um novo produto.
        ///Necessário se autenticar.
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Produto))]
        public IActionResult Create(Produto produto)
        {
            if (produto == null) return BadRequest();

            var result = _productRepository.InserirProduto(produto);           

            return Ok(result);
        }


        /// <summary>
        /// Atualizar um produto.
        ///  Necessário se autenticar.
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(Produto produto)
        {
            if (produto == null) return BadRequest();

            var result = _productRepository.AtualizarProduto(produto);

            return Ok(result);
        }



        /// <summary>
        /// Deletar um produto. 
        /// Necessário se autenticar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            _productRepository.DeletarProduto(id);

            return NoContent();
        }



    }
}
