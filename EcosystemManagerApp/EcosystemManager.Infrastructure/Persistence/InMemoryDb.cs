using EcosystemManager.Domain.Entities;

namespace EcosystemManager.Infrastructure.Persistence
{
    public class InMemoryDb
    {
        private readonly List<Product> _productList = new();
        private int _currentId = 1;

        public List<Product> Products => _productList;

        public Product AddProduct(Product product)
        {
            product.Id = _currentId++;
            _productList.Add(product);
            return product;
        }
    }
}
