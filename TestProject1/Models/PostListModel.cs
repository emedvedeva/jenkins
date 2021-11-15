using System.Collections.Generic;

namespace TestProject1.Models
{
    public class PostListModel
    {
        public List<Post> _posts;
        public PostListModel(List<Post> posts)
        {
            _posts = posts;
        }
        public bool IsSorted()
        {
            //AqualityServices.LocalizedLogger.Info("Checking order posts");
            bool isSorted = true;

            for (int i = 1; i < _posts.Count; i++)
            {
                if (_posts[i - 1].Id > _posts[i].Id) isSorted = false;
            }

            return isSorted;
        }
    }
}
