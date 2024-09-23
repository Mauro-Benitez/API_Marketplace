using API_Marketplace.Domain.Entities;
using API_Marketplace.Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_Marketplace.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(Usuario))]
        public IActionResult Create(Usuario usuario)
        {
            if (usuario == null) return BadRequest();



            var result = _usuarioRepository.NovoUsuario(usuario);

            return Ok(result);
        }
    }
}
