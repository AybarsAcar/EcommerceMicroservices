using System;
using System.Threading.Tasks;
using Ecomm.Web.Models;

namespace Ecomm.Web.Services.IServices
{
  /// <summary>
  /// 
  /// </summary>
  public interface IBaseService : IDisposable
  {
    ResponseDto ResponseModel { get; set; }

    Task<T> SendAsync<T>(ApiRequest apiRequest);
  }
}