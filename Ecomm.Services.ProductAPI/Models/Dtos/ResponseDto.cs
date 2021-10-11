using System.Collections.Generic;

namespace Ecomm.Services.ProductAPI.Models.Dtos
{
  /// <summary>
  /// represents our response object sent from the API
  /// </summary>
  public class ResponseDto
  {
    public bool IsSuccess { get; set; } = true;
    public object Result { get; set; }
    public string DisplayMessage { get; set; } = "";
    public List<string> ErrorMessages { get; set; }
  }
}