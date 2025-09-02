using EcosystemManager.Application.DTO;
using EcosystemManager.Application.Exceptions;
using EcosystemManager.Application.Interface;
using EcosystemManager.Domain.Entities;
using EcosystemManager.Infrastructure.Persistence;


namespace EcosystemManager.Application.Service
{
    /// <summary>
    /// Implementación del servicio de productos que maneja la lógica de negocio.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly InMemoryDb _db;

        public ProductService(InMemoryDb db)
        {
            _db = db;
        }

        public Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_db.Products.AsEnumerable());
        }

        public Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }

        public Task<Product> CreateProductAsync(ProductDto productDto, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(productDto.Name))
            {
                throw new ValidationException("Name", "El nombre del producto es requerido.");
            }
            if (productDto.Price <= 0)
            {
                throw new ValidationException("Price", "El precio debe ser mayor que cero.");
            }

            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity
            };

            var newProduct = _db.AddProduct(product);
            return Task.FromResult(newProduct);
        }


        public async Task UpdateProductAsync(int id, ProductDto productDto, CancellationToken cancellationToken)
        {
            var product = await GetProductByIdAsync(id, cancellationToken);

            if (product is null)
                throw new NotFoundException($"El producto con ID {id} no fue encontrado.");

            if (string.IsNullOrWhiteSpace(productDto.Name))
                throw new ValidationException("Name", "El nombre del producto es requerido.");

            if (productDto.Price <= 0)
                throw new ValidationException("Price", "El precio debe ser mayor que cero.");

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            product.Quantity = productDto.Quantity;

            await Task.CompletedTask;
        }

        public async Task DeleteProductAsync(int id, CancellationToken cancellationToken)
        {
            var product = await GetProductByIdAsync(id, cancellationToken);
            if (product is null)
                throw new NotFoundException($"El producto con ID {id} no fue encontrado.");

            _db.Products.Remove(product);

            await Task.CompletedTask;
        }
    }
}
