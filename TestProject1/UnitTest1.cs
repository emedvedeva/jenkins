using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using TestProject1.Models;
using TestProject1.Utils;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //AqualityServices.LocalizedLogger.Info("Step 1: Getting all posts");
            HttpStatusCode statusCode;
            var posts = ApiApplicationRequests.GetPosts(out statusCode);
            Assert.AreEqual(HttpStatusCode.OK, statusCode, "StatusCode is wrong");
            Assert.IsTrue(posts != null, "The list is not json");
            Assert.IsTrue(posts.IsSorted(), "The list is not sorted acsend");

            //AqualityServices.LocalizedLogger.Info("Step 2: Getting post");
            Post post = ApiApplicationRequests.GetPost("99", out statusCode);
            Assert.AreEqual(HttpStatusCode.OK, statusCode, "StatusCode is wrong");
            Assert.AreEqual(ConfigManager.GetData("step2userid"), post.UserId.ToString(), "The post userId is not correct");
            Assert.AreEqual(ConfigManager.GetData("step2id"), post.Id.ToString(), "The post Id is not correct");


            //AqualityServices.LocalizedLogger.Info("Step 3: Getting post");
            post = ApiApplicationRequests.GetPost("150", out statusCode);
            Assert.AreEqual(HttpStatusCode.NotFound, statusCode, "StatusCode is wrong");
            Assert.IsTrue(post.Id == 0, "The response is not empty");

           // AqualityServices.LocalizedLogger.Info("Step 4: Sending post");
            Post generatedPost = new Post(int.Parse(ConfigManager.GetData("step4userid")));
            Post apipost = ApiApplicationRequests.SendPost(generatedPost, out statusCode);
            Assert.AreEqual(HttpStatusCode.Created, statusCode, "StatusCode is wrong");            
            Assert.IsTrue(apipost.Id > 0, "There is not postId");

            //AqualityServices.LocalizedLogger.Info("Step 5: Getting users");
            UserListModel users = ApiApplicationRequests.GetUsers(out statusCode);
            Assert.AreEqual(HttpStatusCode.OK, statusCode, "StatusCode is wrong");
            Assert.IsTrue(users != null, "The list is not json");
            Assert.IsTrue(UserListModel.Equals(ConfigManager.GetUserFromFile(), users.GetUserById(int.Parse(ConfigManager.GetData("step5userid")))), "The users do not match");

            //AqualityServices.LocalizedLogger.Info("Step 6: Getting user");
            User actualUser = ApiApplicationRequests.GetUser(out statusCode);
            Assert.AreEqual(HttpStatusCode.OK, statusCode, "StatusCode is wrong");
            Assert.IsTrue(UserListModel.Equals(ConfigManager.GetUserFromFile(), actualUser), "The users do not match");
        }
    }
}
