using DevInSales.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInSales.Core.Interfaces
{
    public interface IProductService
    {
        public List<Product> ObterProduct(string titulo);

        public Product? ObterPorId(int id);

        public int CriarProduct(Product product);

        public void AtualizarProduct(Product ProductOriginal, Product ProductAlteracoes);

        public void RemoverProduct(int id);
    }
}
