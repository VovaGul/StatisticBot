using StatisticBot.Providers;
using StatisticBot.Providers.Interfaces;
using StatisticBot.Statistic;
using StatisticBot.Statistic.Base;
using System;

namespace StatisticBot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите логин:");
                var login = Console.ReadLine();
                Console.WriteLine("Введите пароль:");
                var password = Console.ReadLine();
                IPostProvider provider = new VkProvider(login, password);

                Console.WriteLine("Введите аккаунт для получения постов");
                var userId = Console.ReadLine();
                const int postsCount = 5;
                var posts = provider.GetPosts(postsCount, userId); 

                FrequencyCounter counter = new LettersFrequencyCounter();
                var statistic = counter.GetStatistic(String.Join("", posts));
                var statisticMessage = $"{userId}, статистика для последних {postsCount} постов: {statistic}";
                provider.CreatePost(statisticMessage);

                Console.WriteLine("Статистика успешно опубликована");
            }
            catch (Exception еx)
            {
                Console.WriteLine(еx.Message);
            }

            Console.ReadKey();
        }
    }
}
