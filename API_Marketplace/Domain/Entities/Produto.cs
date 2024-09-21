namespace API_Marketplace.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; init; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public int Estoque { get; set; }

        public Produto( string nome, decimal preco, int estoque)
        {
            Id = new Guid();
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
        }
    }
}
