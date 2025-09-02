using EcosystemManager.Application.DTO;
using EcosystemManager.Domain.Entities;

namespace EcosystemManager.Application.Interface
{
    /// <summary>
    /// Define el contrato para el servicio de productos, exponiendo operaciones asíncronas.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Obtiene todos los productos de forma asíncrona.
        /// </summary>
        /// <param name="cancellationToken">Token para monitorear solicitudes de cancelación.</param>
        /// <returns>Una tarea que representa la operación asíncrona y contiene una colección de productos.</returns>
        Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Obtiene un producto por su ID de forma asíncrona.
        /// </summary>
        /// <param name="id">El ID del producto a buscar.</param>
        /// <param name="cancellationToken">Token para monitorear solicitudes de cancelación.</param>
        /// <returns>Una tarea que contiene el producto encontrado o null si no existe.</returns>
        Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Crea un nuevo producto de forma asíncrona.
        /// </summary>
        /// <param name="productDto">Los datos para crear el nuevo producto.</param>
        /// <param name="cancellationToken">Token para monitorear solicitudes de cancelación.</param>
        /// <returns>Una tarea que contiene el producto recién creado.</returns>
        Task<Product?> CreateProductAsync(ProductDto productDto, CancellationToken cancellationToken);

        /// <summary>
        /// Actualiza un producto existente de forma asíncrona.
        /// </summary>
        /// <param name="id">El ID del producto a actualizar.</param>
        /// <param name="productDto">Los nuevos datos para el producto.</param>
        /// <param name="cancellationToken">Token para monitorear solicitudes de cancelación.</param>
        /// <returns>Una tarea que representa la finalización de la operación.</returns>
        /// <exception cref="NotFoundException">Se lanza si el producto con el ID especificado no se encuentra.</exception>
        /// <exception cref="ValidationException">Se lanza si los datos del DTO no son válidos.</exception>
        Task UpdateProductAsync(int id, ProductDto productDto, CancellationToken cancellationToken);

        /// <summary>
        /// Elimina un producto por su ID de forma asíncrona.
        /// </summary>
        /// <param name="id">El ID del producto a eliminar.</param>
        /// <param name="cancellationToken">Token para monitorear solicitudes de cancelación.</param>
        /// <returns>Una tarea que representa la finalización de la operación.</returns>
        /// <exception cref="NotFoundException">Se lanza si el producto con el ID especificado no se encuentra.</exception>
        Task DeleteProductAsync(int id, CancellationToken cancellationToken);
    }
}
