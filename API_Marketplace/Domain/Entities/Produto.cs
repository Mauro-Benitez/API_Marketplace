using System.Text.Json.Serialization;

namespace API_Marketplace.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; private set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public int Estoque { get; set; }

        public Produto()
        {
        }

        [JsonConstructor]
        public Produto(Guid id,string nome, decimal preco, int estoque)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
        }


        public Produto( string nome, decimal preco, int estoque)
        {
            Id = new Guid();
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
        }
    }
}
