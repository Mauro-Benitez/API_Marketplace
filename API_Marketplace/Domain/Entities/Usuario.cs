namespace API_Marketplace.Domain.Entities
{
    public class Usuario
    {
        
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Senha { get; set; }

        public Usuario(string userName, string senha)
        {
            UserName = userName;
            Senha = senha;
        }
    }
}
