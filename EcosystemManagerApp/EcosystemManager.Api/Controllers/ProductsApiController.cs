using EcosystemManager.Application.DTO;
using EcosystemManager.Application.Exceptions;
using EcosystemManager.Application.Interface;
using EcosystemManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace EcosystemManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ProductsApiController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsApiController(IProductService service)
        {
            _productService = service;
        }

        /// <summary>
        /// Obtiene una lista de todos los productos.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación para la operación asíncrona.</param>
        /// <returns>Una lista de productos.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(CancellationToken cancellationToken)
        {
            var products = await _productService.GetProductsAsync(cancellationToken);
            return Ok(products);
        }

        /// <summary>
        /// Busca un producto específico por su ID.
        /// </summary>
        /// <param name="id">El ID del producto a buscar.</param>
        /// <param name="cancellationToken">Token de cancelación para la operación asíncrona.</param>
        /// <returns>El producto encontrado.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductById(int id, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByIdAsync(id, cancellationToken);

            if (product is null)
            {
                return NotFound($"El producto con ID {id} no fue encontrado.");
            }

            return Ok(product);
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="productDto">Los datos del producto a crear.</param>
        /// <param name="cancellationToken">Token de cancelación para la operación asíncrona.</param>
        /// <returns>El producto recién creado.</returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductDto productDto, CancellationToken cancellationToken)
        {
            try
            {
                var newProduct = await _productService.CreateProductAsync(productDto, cancellationToken);
                return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="id">El ID del producto a actualizar.</param>
        /// <param name="productDto">Los nuevos datos para el producto.</param>
        /// <param name="cancellationToken">Token de cancelación para la operación asíncrona.</param>
        /// <returns>Una respuesta sin contenido si la actualización fue exitosa.</returns>
        [HttpPut("{id:int}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto, CancellationToken cancellationToken)
        {
            try
            {
                await _productService.UpdateProductAsync(id, productDto, cancellationToken);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto a eliminar.</param>
        /// <param name="cancellationToken">Token de cancelación para la operación asíncrona.</param>
        /// <returns>Una respuesta sin contenido si la eliminación fue exitosa.</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            try
            {
                await _productService.DeleteProductAsync(id, cancellationToken);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
