using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecomm.Services.ProductAPI.Models.Dtos;
using Ecomm.Services.ProductAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecomm.Services.ProductAPI.Controllers
{
  [Route("api/products")]
  public class ProductApiController : ControllerBase
  {
    private readonly IProductRepository _productRepository;
    private readonly ResponseDto _response;

    public ProductApiController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
      _response = new ResponseDto();
    }

    [HttpGet]
    public async Task<object> Get()
    {
      try
      {
        var productDtos = await _productRepository.GetProductsAsync();
        _response.Result = productDtos;
      }
      catch (Exception e)
      {
        _response.IsSuccess = false;
        _response.ErrorMessages = new List<string> { e.ToString() };
      }

      return _response;
    }

    [HttpGet("{id}")]
    public async Task<object> Get(int id)
    {
      try
      {
        var productDto = await _productRepository.GetProductByIdAsync(id);
        _response.Result = productDto;
      }
      catch (Exception e)
      {
        _response.IsSuccess = false;
        _response.ErrorMessages = new List<string> { e.ToString() };
      }

      return _response;
    }

    [HttpPost]
    public async Task<object> Post([FromBody] ProductDto productDto)
    {
      try
      {
        var resultDto = await _productRepository.CreateUpdateProductAsync(productDto);
        _response.Result = resultDto;
      }
      catch (Exception e)
      {
        _response.IsSuccess = false;
        _response.ErrorMessages = new List<string> { e.ToString() };
      }

      return _response;
    }

    [HttpPut]
    public async Task<object> Put([FromBody] ProductDto productDto)
    {
      try
      {
        var resultDto = await _productRepository.CreateUpdateProductAsync(productDto);
        _response.Result = resultDto;
      }
      catch (Exception e)
      {
        _response.IsSuccess = false;
        _response.ErrorMessages = new List<string> { e.ToString() };
      }

      return _response;
    }

    [HttpDelete]
    public async Task<object> Delete(int id)
    {
      try
      {
        var isSuccess = await _productRepository.DeleteProductAsync(id);
        _response.Result = isSuccess;
      }
      catch (Exception e)
      {
        _response.IsSuccess = false;
        _response.ErrorMessages = new List<string> { e.ToString() };
      }

      return _response;
    }
  }
}