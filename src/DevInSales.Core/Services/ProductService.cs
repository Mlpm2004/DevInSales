using DevInSales.Core.Data.Context;
using DevInSales.Core.Entities;
using DevInSales.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DevInSales.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public List<Product> ObterProduct(string name)
        {
            return _context.Products
                .Include(p => p.Name)
                .Include(p => p.SuggestedPrice)
                .Where(p => string.IsNullOrWhiteSpace(name) || p.Name.Contains(name))
                .ToList();
        }

        public Product? ObterPorId(int id)
        {
            return _context.Products
                .Include(p => p.Name)
                .Include(p => p.SuggestedPrice)
                .FirstOrDefault(p => p.Id == id);
        }

        public int CriarProduct(Product Product)
        {
            _context.Products.Add(Product);
            _context.SaveChanges();
            return Product.Id;
        }

        public void AtualizarProduct(Product ProductOriginal, Product ProductAlteracoes)
        {
            ProductOriginal.AlterarDados( ProductAlteracoes.Name,
                                          ProductAlteracoes.SuggestedPrice);
            _context.SaveChanges();
        }

        public void RemoverProduct(int id)
        {
            var Product = ObterPorId(id);
            if (Product == null)
                throw new Exception("O Produto com o identificador informado não existe");

            _context.Products.Remove(Product);
            _context.SaveChanges();
        }
    }
 
}
