using RestSharp;
using TestProject1.Models;

namespace TestProject1.Utils
{
    public static class ApiUtils
    {
        public static ResponseModel Get(string url, string path)
        {
            //AqualityServices.LocalizedLogger.Info($"Getting request get {url}{path}");
            var client = new RestClient(url);
            var request = new RestRequest(path);
            return new ResponseModel { StatusCode = client.Get(request).StatusCode, Content = client.Get(request).Content };
        }

        public static ResponseModel Post(string url, string path, Post post)
        {
            //AqualityServices.LocalizedLogger.Info($"Getting request post  {url}{path}");
            var client = new RestClient(url);
            var request = new RestRequest(path);
            request.AddJsonBody(post);            
            return new ResponseModel { StatusCode = client.Post(request).StatusCode, Content = client.Post(request).Content };
        }
    }
}
