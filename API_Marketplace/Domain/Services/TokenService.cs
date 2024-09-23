using API_Marketplace.Domain.Entities;
using API_Marketplace.Infraestructure.DataBase;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace API_Marketplace.Domain.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SQLContext _context;

        public TokenService(IConfiguration configuration, SQLContext context)
        {
            _context = context;
           _configuration = configuration;
        }

        public string GetToken(Usuario usuario)
        {
            var result = _context.Usuarios.Any(u => u.UserName == usuario.UserName && u.Senha == usuario.Senha);

            if(!result)
            {
                return string.Empty;
            }

            // Variável responsável por gerar o token
            var tokenHandler = new JwtSecurityTokenHandler();

            // Recupera a chave que criamos no nosso appSettings e convert para um array de bytes
            var chaveCriptografia = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT"));

            // O Descriptor é responsável por definir todas as propriedades que o nosso token terá quando descriptografarmos
            var tokenPropriedades = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.UserName)
                }),

                // Tempo de expiração do token
                Expires = DateTime.UtcNow.AddHours(8),

                // Adiciona a nossa chave de criptografia
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chaveCriptografia), SecurityAlgorithms.HmacSha256Signature)

            };

            // Cria o nosso token e devolve pro método solicitante
            var token = tokenHandler.CreateToken(tokenPropriedades);
            return tokenHandler.WriteToken(token);
        }
    }
}
