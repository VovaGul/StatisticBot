using System.Collections.Generic;
using StatisticBot.Providers.Interfaces;

namespace StatisticBot.Providers
{
    public class TwitterProvider : IPostProvider
    {
        public bool CreatePost(string message)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetPosts(int count, string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}
