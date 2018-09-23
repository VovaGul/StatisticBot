using System.Collections.Generic;

namespace StatisticBot.Providers.Interfaces
{
    public interface IPostProvider
    {
        IEnumerable<string> GetPosts(int count, string userId);
        bool CreatePost(string message);
    }
}
