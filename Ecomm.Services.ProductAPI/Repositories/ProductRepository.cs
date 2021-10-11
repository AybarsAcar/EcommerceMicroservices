using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ecomm.Services.ProductAPI.DataContext;
using Ecomm.Services.ProductAPI.Models;
using Ecomm.Services.ProductAPI.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Ecomm.Services.ProductAPI.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
      return _mapper.Map<IEnumerable<ProductDto>>(await _context.Products.ToListAsync());
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
      return _mapper.Map<ProductDto>(await _context.Products.FirstOrDefaultAsync(x => x.Id == id));
    }

    public async Task<ProductDto> CreateUpdateProductAsync(ProductDto productDto)
    {
      var product = _mapper.Map<Product>(productDto);

      if (product.Id > 0)
      {
        // updating the product
        _context.Products.Update(product);
      }
      else
      {
        await _context.Products.AddAsync(product);
      }

      await _context.SaveChangesAsync();
      return _mapper.Map<ProductDto>(product);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
      try
      {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product == null)
        {
          return false;
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return true;
      }
      catch (Exception e)
      {
        return false;
      }
    }
  }
}