using System.Threading.Tasks;
using Ecomm.Web.Models;

namespace Ecomm.Web.Services.IServices
{
  public interface IProductService : IBaseService
  {
    /// <summary>
    /// method to request to get all the products
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public Task<T> GetProductsAsync<T>();

    /// <summary>
    /// request to get a product by its id
    /// </summary>
    /// <param name="id"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public Task<T> GetProductByIdAsync<T>(int id);

    /// <summary>
    /// request to create a product by a product dto
    /// </summary>
    /// <param name="productDto"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public Task<T> CreateProductAsync<T>(ProductDto productDto);

    /// <summary>
    ///  request to update a product by a product dto
    /// </summary>
    /// <param name="productDto"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public Task<T> UpdateProductAsync<T>(ProductDto productDto);

    /// <summary>
    /// request to delete a product by its id
    /// </summary>
    /// <param name="id"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public Task<T> DeleteProductAsync<T>(int id);
  }
}