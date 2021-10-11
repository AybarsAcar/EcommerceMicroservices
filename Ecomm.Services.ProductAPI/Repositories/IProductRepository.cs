using System.Collections.Generic;
using System.Threading.Tasks;
using Ecomm.Services.ProductAPI.Models.Dtos;

namespace Ecomm.Services.ProductAPI.Repositories
{
  /// <summary>
  /// Product Database access layer
  /// </summary>
  public interface IProductRepository
  {
    /// <summary>
    /// returns all the products in the database
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<ProductDto>> GetProductsAsync();

    /// <summary>
    /// returns a product based on the id passed
    /// </summary>
    /// <param name="id">Product Id</param>
    /// <returns></returns>
    public Task<ProductDto> GetProductByIdAsync(int id);

    /// <summary>
    /// Creates / Updates a product passed in a product dto object
    /// </summary>
    /// <param name="productDto"></param>
    /// <returns></returns>
    public Task<ProductDto> CreateUpdateProductAsync(ProductDto productDto);

    /// <summary>
    /// deletes a product entry based on the id passed in
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> DeleteProductAsync(int id);
  }
}