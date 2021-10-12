using System.Net.Http;
using System.Threading.Tasks;
using Ecomm.Web.Models;
using Ecomm.Web.Services.IServices;

namespace Ecomm.Web.Services
{
  public class ProductService : BaseService, IProductService
  {
    private readonly IHttpClientFactory _httpClient;

    public ProductService(IHttpClientFactory httpClient) : base(httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<T> GetProductsAsync<T>()
    {
      return await SendAsync<T>(new ApiRequest
      {
        ApiType = Constants.ApiType.Get,
        Url = Constants.ProductApiBase + "/api/products",
        AccessToken = ""
      });
    }

    public async Task<T> GetProductByIdAsync<T>(int id)
    {
      return await SendAsync<T>(new ApiRequest
      {
        ApiType = Constants.ApiType.Get,
        Url = Constants.ProductApiBase + $"/api/products/{id}",
        AccessToken = ""
      });
    }

    public async Task<T> CreateProductAsync<T>(ProductDto productDto)
    {
      return await SendAsync<T>(new ApiRequest
      {
        ApiType = Constants.ApiType.Post,
        Data = productDto,
        Url = Constants.ProductApiBase + "/api/products",
        AccessToken = ""
      });
    }

    public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
    {
      return await SendAsync<T>(new ApiRequest
      {
        ApiType = Constants.ApiType.Put,
        Data = productDto,
        Url = Constants.ProductApiBase + "/api/products",
        AccessToken = ""
      });
    }

    public async Task<T> DeleteProductAsync<T>(int id)
    {
      return await SendAsync<T>(new ApiRequest
      {
        ApiType = Constants.ApiType.Delete,
        Url = Constants.ProductApiBase + $"/api/products/{id}",
        AccessToken = ""
      });
    }
  }
}