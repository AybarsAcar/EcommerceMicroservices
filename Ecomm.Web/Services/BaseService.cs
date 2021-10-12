using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ecomm.Web.Models;
using Ecomm.Web.Services.IServices;
using Newtonsoft.Json;

namespace Ecomm.Web.Services
{
  public class BaseService : IBaseService
  {
    public void Dispose()
    {
      GC.SuppressFinalize(true);
    }

    public ResponseDto ResponseModel { get; set; }

    public IHttpClientFactory HttpClient { get; set; }

    public BaseService(IHttpClientFactory httpClient)
    {
      ResponseModel = new ResponseDto();
      HttpClient = httpClient;
    }

    public async Task<T> SendAsync<T>(ApiRequest apiRequest)
    {
      try
      {
        var client = HttpClient.CreateClient("EcommApi");

        var message = new HttpRequestMessage();
        message.Headers.Add("Accept", "application/json");
        message.RequestUri = new Uri(apiRequest.Url);

        client.DefaultRequestHeaders.Clear();

        if (apiRequest.Data != null)
        {
          // serialise the data
          message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8,
            "application/json");
        }

        HttpResponseMessage apiResponseMessage = null;

        message.Method = apiRequest.ApiType switch
        {
          Constants.ApiType.Post => HttpMethod.Post,
          Constants.ApiType.Put => HttpMethod.Put,
          Constants.ApiType.Delete => HttpMethod.Delete,
          _ => HttpMethod.Get
        };

        apiResponseMessage = await client.SendAsync(message);

        var apiContent = await apiResponseMessage.Content.ReadAsStringAsync();

        // convert back to the object
        var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);

        return apiResponseDto;
      }
      catch (Exception e)
      {
        var dto = new ResponseDto
        {
          DisplayMessage = "Error",
          ErrorMessages = new List<string> { Convert.ToString(e.Message) },
          IsSuccess = false,
        };

        var res = JsonConvert.SerializeObject(dto);

        var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
        return apiResponseDto;
      }
    }
  }
}