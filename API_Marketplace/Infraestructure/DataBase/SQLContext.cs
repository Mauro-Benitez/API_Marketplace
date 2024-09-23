using API_Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Marketplace.Infraestructure.DataBase
{
    public class SQLContext : DbContext
    {
        public SQLContext()
        {
        }
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }




    }
}
