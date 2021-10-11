using AutoMapper;
using Ecomm.Services.ProductAPI.Models;
using Ecomm.Services.ProductAPI.Models.Dtos;

namespace Ecomm.Services.ProductAPI
{
  /// <summary>
  /// Configuration class for AutoMapper
  /// </summary>
  public class MappingConfiguration
  {
    public static MapperConfiguration ConfigureMaps()
    {
      var mappingConfig = new MapperConfiguration(config =>
      {
        config.CreateMap<Product, ProductDto>();
        config.CreateMap<ProductDto, Product>();
      });

      return mappingConfig;
    }
  }
}