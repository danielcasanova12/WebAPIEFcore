using WebAPIEFcore.Models;

namespace WebAPIEFcore.Data
{
    public class PovoaBanco
    {
        private readonly AppDbContext _context;

        public PovoaBanco(AppDbContext context)
        {
            _context = context;
        }

        public void PopularBaseDeDados()
        {
            var products = new List<Product>
            {
                new Product { ProductId = 1, Nome = "Banana", Preco = 4.6f, Quantidade = 7 },
                new Product { ProductId = 2, Nome = "Pera", Preco = 4.6f, Quantidade = 7 },
                new Product { ProductId = 3, Nome = "Maçã", Preco = 4.6f, Quantidade = 7 },
                new Product { ProductId = 4, Nome = "Melão", Preco = 4.6f, Quantidade = 7 }
            };

            _context.Products.AddRange(products);
            _context.SaveChanges();
        }
    }
}