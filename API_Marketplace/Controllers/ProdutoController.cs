using API_Marketplace.Domain.Entities;
using API_Marketplace.Infraestructure.Repository;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(List<Produto>))]
        public IActionResult GetAll()
        {
            var result = _productRepository.ListarProdutos();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Produto))]
        public IActionResult GetById(Guid id)
        {
            var result = _productRepository.GetByIdProduto(id);

            if (result == null) return NotFound();

            return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Produto))]
        public IActionResult Create(Produto produto)
        {
            if (produto == null) return BadRequest();

            var result = _productRepository.InserirProduto(produto);           

            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]     
        public IActionResult Update(Produto produto)
        {
            if (produto == null) return BadRequest();

            var result = _productRepository.AtualizarProduto(produto);

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            _productRepository.DeletarProduto(id);

            return NoContent();
        }



    }
}
