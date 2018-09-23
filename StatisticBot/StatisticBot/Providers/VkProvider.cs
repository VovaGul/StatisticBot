using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System;
using StatisticBot.Providers.Interfaces;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace StatisticBot.Providers
{
    public class VkProvider : IPostProvider
    {
        private readonly VkApi _api;
        private readonly ulong _applicationId;
        private readonly string _login;
        private readonly string _password;

        public VkProvider(string login, string password)
        {
            _api = new VkApi();
            _login = login;
            _password = password;
            _applicationId = Convert.ToUInt64(ConfigurationManager.AppSettings.Get("VkApplicationId"));

            Authorize();
        }

        public bool CreatePost(string message)
        {
            Authorize();

            var parameters = new WallPostParams()
            {
                Message = message
            };
            var result = _api.Wall.Post(parameters);

            return result != default(long);
        }

        public IEnumerable<string> GetPosts(int count, string userId)
        {
            Authorize();

            var parameters = new WallGetParams()
            {
                Domain = userId,
                Count = (ulong)count
            };
            var posts = _api.Wall.Get(parameters);
            var result = posts.WallPosts.Select(p => p.Text);

            return result;
        }

        private void Authorize()
        {
            if (_api.IsAuthorized) return;

            var authParameters = new ApiAuthParams
            {
                ApplicationId = _applicationId,
                Login = _login,
                Password = _password,
                Settings = Settings.All
            };

            try
            {
                _api.Authorize(authParameters);
            }
            catch (Exception)
            {
                throw new ArgumentException("Ошибка авторизации, проверьте логин и пароль");
            }

        }
    }
}
