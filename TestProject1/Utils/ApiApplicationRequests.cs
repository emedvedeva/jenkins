using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using TestProject1.Models;

namespace TestProject1.Utils
{
    public static class ApiApplicationRequests
    {
        public static PostListModel GetPosts(out HttpStatusCode statusCode)
        {
            //AqualityServices.LocalizedLogger.Info("Getting response content GetPosts");
            var response = ApiUtils.Get(ConfigManager.GetData("url"), ConfigManager.GetData("step1"));
            statusCode = response.StatusCode;
            return new PostListModel(JsonConvert.DeserializeObject<List<Post>>(response.Content));
        }

        public static Post GetPost(string postNumber, out HttpStatusCode statusCode)
        {
            //AqualityServices.LocalizedLogger.Info("Getting response content GetPost");
            var response = ApiUtils.Get(ConfigManager.GetData("url"), (ConfigManager.GetData("step2")+postNumber));
            statusCode = response.StatusCode;            
            return JsonConvert.DeserializeObject<Post>(response.Content);
        }        

        public static Post SendPost(Post generatedPost, out HttpStatusCode statusCode)
        {
            //AqualityServices.LocalizedLogger.Info("Getting response content SendPost");
            var response = ApiUtils.Post(ConfigManager.GetData("url"), ConfigManager.GetData("step4"), generatedPost);
            statusCode = response.StatusCode;
            if (response.Content=="{}")
            {
                Post post = new Post();
                post.Id = 0;
                return post;
            }
            else
            {
                return JsonConvert.DeserializeObject<Post>(response.Content);
            }            
        }

        public static UserListModel GetUsers(out HttpStatusCode statusCode)
        {
           // AqualityServices.LocalizedLogger.Info("Getting response content GetUsers");
            var response = ApiUtils.Get(ConfigManager.GetData("url"), ConfigManager.GetData("step5"));
            statusCode = response.StatusCode; ;
            return new UserListModel(JsonConvert.DeserializeObject<List<User>>(response.Content));
        }

        public static User GetUser(out HttpStatusCode statusCode)
        {
            //AqualityServices.LocalizedLogger.Info("Getting response content GetUser");
            var response = ApiUtils.Get(ConfigManager.GetData("url"), ConfigManager.GetData("step6")+ConfigManager.GetData("step5userid"));
            statusCode = response.StatusCode; ;
            return JsonConvert.DeserializeObject<User>(response.Content);
        }       
    }
}
