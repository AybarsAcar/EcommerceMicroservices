using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecomm.Web.Models;
using Ecomm.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecomm.Web.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
      _productService = productService;
    }

    public async Task<IActionResult> ProductIndex()
    {
      var list = new List<ProductDto>();

      var response = await _productService.GetProductsAsync<ResponseDto>();

      if (response != null && response.IsSuccess)
      {
        list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result) ?? throw new
          InvalidOperationException());
      }

      return View(list);
    }
  }
}