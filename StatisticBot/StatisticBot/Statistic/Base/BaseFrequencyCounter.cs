using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace StatisticBot.Statistic.Base
{
    public abstract class FrequencyCounter
    {
        private const string FrequencyFormat = "F4";
        public string GetStatistic(string message)
        {
            var characters = message.ToCharArray();
            var charactersCount = new Dictionary<char, int>();
            var totalCount = 0;

            foreach (var character in characters)
            {
                if (!IsCountedCharacter(character)) continue;

                totalCount++;

                if (charactersCount.ContainsKey(character))
                {
                    charactersCount[character]++;
                }
                else
                {
                    charactersCount.Add(character, 1);
                }
            }

            var charactersFrequency =
                charactersCount.OrderBy(c => c.Key)
                    .ToDictionary(c => c.Key, c => ((double) c.Value / totalCount).ToString(FrequencyFormat));
            var result = JsonConvert.SerializeObject(charactersFrequency);

            return result;
        }

        protected abstract bool IsCountedCharacter(char character);
    }
}
