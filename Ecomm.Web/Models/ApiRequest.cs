using static Ecomm.Web.Constants;

namespace Ecomm.Web.Models
{
  /// <summary>
  /// model of the request we make
  /// </summary>
  public class ApiRequest
  {
    public ApiType ApiType { get; set; } = ApiType.Get;
    public string Url { get; set; }
    public object Data { get; set; }
    public string AccessToken { get; set; }
  }
}