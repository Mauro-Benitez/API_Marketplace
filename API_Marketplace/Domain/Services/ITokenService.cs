using API_Marketplace.Domain.Entities;

namespace API_Marketplace.Domain.Services
{
    public interface ITokenService
    {

        public string GetToken(Usuario usuario);


    }
}
