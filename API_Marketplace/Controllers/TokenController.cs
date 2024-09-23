using API_Marketplace.Domain.Entities;
using API_Marketplace.Domain.Services;
using API_Marketplace.Infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API_Marketplace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Passar login e senha para gerar um novo token.      
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]       
        public IActionResult CreateToken([FromBody] Usuario usuario)
        {
            var result = _tokenService.GetToken(usuario);

            if (!string.IsNullOrWhiteSpace(result))
            {
                return Ok(result);
            }


            return Unauthorized();
        }
    }
}

