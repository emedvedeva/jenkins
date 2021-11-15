using System.Net;

namespace TestProject1.Models
{
    public class ResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Content { get; set; }
    }
}
