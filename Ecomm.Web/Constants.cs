namespace Ecomm.Web
{
  public static class Constants
  {
    public static string ProductApiBase { get; set; }

    public enum ApiType
    {
      Get,
      Post,
      Put,
      Delete
    }
  }
}