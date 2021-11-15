using TestProject1.Utils;

namespace TestProject1.Models
{
    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public Post()
        {

        }
        public Post (int userId)
        {
            //AqualityServices.LocalizedLogger.Info("Creating post");
            UserId = userId;
            Body = StringUtils.GetRandomText(int.Parse(ConfigManager.GetData("minTextLength")), int.Parse(ConfigManager.GetData("maxTextLength")));
            Title = StringUtils.GetRandomText(int.Parse(ConfigManager.GetData("minTextLength")), int.Parse(ConfigManager.GetData("maxTextLength")));
        }        
    }
}
